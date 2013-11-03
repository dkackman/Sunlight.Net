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

        public PoliticalPartyTimeService(string api_key)
        {
            _service = new SunlightService("http://politicalpartytime.org/api/v1", api_key);
        }

        public async Task<FilterResults> FilterEvents(DateTime start_date__gt, string beneficiaries__crp_id = null, string host__id = null, string beneficiaries__state = null)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("format", "json");
            parms.Add("start_date__gt", start_date__gt.ToString("yyyy-MM-dd"));
            parms.Add("beneficiaries__crp_id", beneficiaries__crp_id);
            parms.Add("host__id", host__id);
            parms.Add("beneficiaries__state", beneficiaries__state);

            return await _service.Get<FilterResults>("/event/", parms);
        }
    }
}
