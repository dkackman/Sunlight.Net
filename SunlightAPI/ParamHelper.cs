using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Diagnostics;

namespace SunlightAPI
{
    static class ParamHelper
    {
        /// <summary>
        /// Well... I am not super happy with this implementation but
        /// the Congress API allows searching on a subset of the properties json return type.
        /// http://tryit.sunlightfoundation.com/congress
        /// i.e. to search the database you provide an object prototype
        /// this method will receurse an object instance
        /// find all proeprties marked as searchable and add them to a dictionary
        /// said dictionary is then used to construct the correct query string such like this
        /// congress.api.sunlightfoundation.com/bills?query=health&history.house_passage_result=pass&history.senate_passage_result=fail 
        /// which would be all bills passed by the house but rejected by the senate
        /// </summary>
        /// <param name="parms"></param>
        /// <param name="o"></param>
        /// <param name="prefix"></param>
        public static void AddSearchableProperties(this IDictionary<string, object> parms, object o, string prefix = "")
        {
            Debug.Assert(parms != null);
            if (o == null)
                return;

            foreach (var p in o.GetType().GetRuntimeProperties().Where(p => p.GetCustomAttribute<SearchablePropertyAttribute>() != null))
                parms.AddProperty(p, o, prefix);
        }


        public static void AddProperties(this IDictionary<string, object> parms, object o, string prefix = "")
        {
            Debug.Assert(parms != null);
            if (o == null)
                return;

            foreach (var p in o.GetType().GetRuntimeProperties())
                parms.AddProperty(p, o, prefix);
        }

        private static void AddProperty(this IDictionary<string, object> parms, PropertyInfo p, object o, string prefix = "")
        {
            object value = p.GetValue(o);
            // filter out sentinals values for unitialized search fields
            if (value != null && !value.Equals(0) && !value.Equals(DateTime.MinValue))
            {
                // if the property is a string just add it
                if (value is string)
                    parms.Add(prefix + p.Name, value);

                // value types
                else if (value.GetType().GetTypeInfo().IsValueType)
                {             
                    // serialize dates in the correct format
                    if (value is DateTime)
                        parms.Add(prefix + p.Name, ((DateTime)value).ToString("yyyy-MM-dd"));
                    else
                        parms.Add(prefix + p.Name, value);
                }

                // the property is a list in which case search on the first item's value - committee_ids is an example
                else if (value is IList<string> && ((IList<string>)value).Count > 0)
                    parms.Add(prefix + p.Name, ((IList<string>)value)[0]);

                // the property is marked as searchable but is a sub ojbect - recurse adding 
                // this property name as a prefix (history.house_passage_result is an example)
                else
                    parms.AddProperties(value, p.Name + ".");
            }
        }
    }
}
