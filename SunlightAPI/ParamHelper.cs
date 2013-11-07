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
            if (o == null)
                return;

            Debug.Assert(parms != null);

            foreach (var p in o.GetType().GetRuntimeProperties().Where(p => p.GetCustomAttribute<SearchablePropertyAttribute>() != null))
            {
                // first off null values are ignored
                object value = p.GetValue(o);
                if (value != null)
                {
                    // if the property is a string or value type add it as a param
                    if (value is string || (value.GetType().GetTypeInfo().IsValueType && !value.Equals(0)))
                        parms.Add(prefix + p.Name, value);

                    // the property is a list in which case search on the first item's value - committee_ids is an example
                    else if (value is IList<string> && ((IList<string>)value).Count > 0)
                        parms.Add(prefix + p.Name, ((IList<string>)value)[0]);

                    // the property is marked as searchable but is a sub ojbect - recurse adding 
                    // this property name as a prefix (history.house_passage_result is an example)
                    else
                        parms.AddSearchableProperties(value, p.Name + ".");
                }
            }
        }


        public static void AddProperties(this IDictionary<string, object> parms, object o, string prefix = "")
        {
            if (o == null)
                return;

            Debug.Assert(parms != null);

            foreach (var p in o.GetType().GetRuntimeProperties())
            {
                // first off null values are ignored
                object value = p.GetValue(o);
                if (value != null)
                {
                    // if the property is a string or value type add it as a param
                    if (value is string || (value.GetType().GetTypeInfo().IsValueType && !value.Equals(0)))
                        parms.Add(prefix + p.Name, value);

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
}
