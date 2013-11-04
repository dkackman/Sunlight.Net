using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Diagnostics;

using PortableRest;

namespace SunlightAPI
{
    class SunlightService
    {
        string _root;

        string apikey_param;

        public SunlightService(string root, string api_key)
        {
            _root = root;
            apikey_param = "&apikey=" + api_key;
        }
        public async Task<T> Get<T>(string resource) where T : class
        {
            Debug.WriteLine(resource);

            var client = new RestClient();
            client.BaseUrl = _root;

            var request = new RestRequest(resource);

            return await client.ExecuteAsync<T>(request);
        }

        public async Task<T> Get<T>(string endPoint, IDictionary<string, object> parms) where T : class
        {
            Debug.Assert(parms != null);

            return await Get<T>(FormatResource(endPoint, parms));
        }

        /// <summary>
        /// I cannot get the PortableRest client to put the parameters on the url so we'll do it ourselves
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        private string FormatResource(string endPoint, IDictionary<string, object> parms)
        {
            if (parms.Count == 0)
                return "";

            // ignore all params where the value is null
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
