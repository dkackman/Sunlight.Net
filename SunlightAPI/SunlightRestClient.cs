using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;

using PortableRest;

namespace SunlightAPI
{
    class SunlightRestClient : RestClient
    {
        string apikey_param;

        public SunlightRestClient(string root, string api_key, string user_agent)
        {
            BaseUrl = root;
            UserAgent = user_agent;
            apikey_param = "?apikey=" + api_key;
        }

        public async Task<T> Get<T>(string resource) where T : class
        {
            Debug.WriteLine(resource);

            var request = new RestRequest(resource, HttpMethod.Get);
            request.ContentType = ContentTypes.FormUrlEncoded;
            return await ExecuteAsync<T>(request);
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
            // format the first param without an &
            StringBuilder builder = new StringBuilder(endPoint + apikey_param);

            // ignore all params where the value is null
            // now append all subsequent params with an &
            foreach (var kvp in parms.Where(kvp => kvp.Value != null))
                builder.AppendFormat("&{0}={1}", WebUtility.UrlEncode(kvp.Key), WebUtility.UrlEncode(kvp.Value.ToString()));

            return builder.ToString();
        }
    }
}
