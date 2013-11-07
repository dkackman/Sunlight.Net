using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunlightAPI.PoliticalPartyTime
{
    public class PoliticalPartyTimeService : IPoliticalPartyTimeService
    {
        private SunlightRestClient _service;

        private const string host = "http://politicalpartytime.org";
        private const string apiV = "api/v1";

        public PoliticalPartyTimeService(string api_key, string user_agent = "")
        {
            _service = new SunlightRestClient(host, api_key, user_agent);
        }

        public async Task<T> GetNext<T>(string request) where T : class
        {
            return await _service.Get<T>(request);
        }

        public async Task<FilterResults<Event>> FindEvents(DateTime start_date__gt, string beneficiaries__crp_id = null, string host__id = null, string beneficiaries__state = null)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("format", "json");
            parms.Add("start_date__gt", start_date__gt.ToString("yyyy-MM-dd"));
            parms.Add("beneficiaries__crp_id", beneficiaries__crp_id);
            parms.Add("host__id", host__id);
            parms.Add("beneficiaries__state", beneficiaries__state);

            return await _service.Get<FilterResults<Event>>(apiV + "/event/", parms);
        }

        public async Task<Event> GetEvent(string id)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("format", "json");

            return await _service.Get<Event>(string.Format("{0}/event/{1}/", apiV, id), parms);
        }

        public async Task<FilterResults<Beneficiary>> FindLegislators(string crp_id = null)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("format", "json");
            parms.Add("crp_id", crp_id);

            return await _service.Get<FilterResults<Beneficiary>>(apiV + "/lawmaker/", parms);
        }

        public async Task<Beneficiary> GetLegislator(string id)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("format", "json");

            return await _service.Get<Beneficiary>(string.Format("{0}/lawmaker/{1}/", apiV, id), parms);
        }

        public async Task<FilterResults<Host>> GetHosts()
        {
            var parms = new Dictionary<string, object>();
            parms.Add("format", "json");

            return await _service.Get<FilterResults<Host>>(apiV + "/host/", parms);
        }

        public async Task<Host> GetHost(string id)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("format", "json");

            return await _service.Get<Host>(string.Format("{0}/host/{1}/", apiV, id), parms);
        }
    }
}
