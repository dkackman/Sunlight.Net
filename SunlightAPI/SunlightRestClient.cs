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
        public SunlightRestClient(string root, string api_key, string user_agent)
        {
            BaseUrl = root;
            UserAgent = user_agent;

            AddHeader("X-APIKEY", api_key);
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

            var request = new RestRequest(endPoint, HttpMethod.Get);
            request.ContentType = ContentTypes.FormUrlEncoded;

            foreach (var kvp in parms.Where(kvp => kvp.Value != null))
                request.AddQueryString(kvp.Key, kvp.Value.ToString());

            return await ExecuteAsync<T>(request);
        }
    }
}
