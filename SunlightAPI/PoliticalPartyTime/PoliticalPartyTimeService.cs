using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.PoliticalPartyTime
{
    public class PoliticalPartyTimeService : IPoliticalPartyTimeService
    {
        private SunlightService _service;

        private const string host = "http://politicalpartytime.org";
        private const string apiV = "api/v1";

        public PoliticalPartyTimeService(string api_key)
        {///api/v1/event/?offset=50&apikey=e5883b15e17d4e1f8d93babda91160c6&limit=50&start_date__gt=2013-01-01&format=json
            _service = new SunlightService(host, api_key);
        }

        public async Task<T> GetNext<T>(string request) where T : class
        {
            return await _service.Get<T>(request);
        }

        public async Task<FilterResults> FilterEvents(DateTime start_date__gt, string beneficiaries__crp_id = null, string host__id = null, string beneficiaries__state = null)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("format", "json");
            parms.Add("start_date__gt", start_date__gt.ToString("yyyy-MM-dd"));
            parms.Add("beneficiaries__crp_id", beneficiaries__crp_id);
            parms.Add("host__id", host__id);
            parms.Add("beneficiaries__state", beneficiaries__state);

            return await _service.Get<FilterResults>(apiV + "/event/", parms);
        }

        public async Task<EventResult> GetEventById(string id)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("format", "json");

            return await _service.Get<EventResult>(string.Format("{0}/event/{1}/", apiV, id), parms);
        }
    }
}
