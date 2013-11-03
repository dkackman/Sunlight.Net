using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Diagnostics;

using PortableRest;

namespace SunlightAPI
{
    static class Sunlight
    {
        const string root = "http://capitolwords.org/api/1";

        const string api_key = "e5883b15e17d4e1f8d93babda91160c6";

        const string apikey_param = "&apikey=" + api_key;

        public static async Task<T> Get<T>(string endPoint, IDictionary<string, object> parms) where T : class
        {
            Debug.Assert(parms != null);
            
            var client = new RestClient();
            client.BaseUrl = root;
            client.UserAgent = "Sunlight client for Windows Phone 8 (v0.01)";

            string resource = FormatResource(endPoint, parms);
            Debug.WriteLine(resource);
            var request = new RestRequest(resource);
            
            return await client.ExecuteAsync<T>(request);
        }

        /// <summary>
        /// I cannot get the PortableRest client to put the parameters on the url so we'll do it ourselves
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        private static string FormatResource(string endPoint, IDictionary<string, object> parms)
        {
            if (parms.Count == 0)
                return "";

            // ignore and params where the value is null
            var nonNulls = parms.Where(kvp => kvp.Value != null);

            // format the first param without an &
            StringBuilder builder = new StringBuilder(endPoint + "?");
            var first = nonNulls.First();
            builder.AppendFormat("{0}={1}", WebUtility.UrlEncode(first.Key), WebUtility.UrlEncode(first.Value.ToString()));

            // now append all subsequent params with an &
            foreach (var kvp in nonNulls.Skip(1))
                builder.AppendFormat("&{0}={1}", WebUtility.UrlEncode(kvp.Key), WebUtility.UrlEncode(kvp.Value.ToString()));

            // add our api key
            builder.Append(apikey_param);

            return builder.ToString();
        }
    }
}
