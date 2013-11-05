using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Diagnostics;

namespace SunlightAPI.Congress
{
    static class ParamHelper
    {
        public static void AddSearchableProperties(this IDictionary<string, object> parms, object o)
        {
            if (o == null)
                return;

            Debug.Assert(parms != null);

            foreach (var p in o.GetType().GetRuntimeProperties().Where(p => p.GetCustomAttribute<SearchablePropertyAttribute>() != null))
            {
                object value = p.GetValue(o);
                if (value != null)
                    parms.Add(p.Name, value);
            }
        }
    }
}
