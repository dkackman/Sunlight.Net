using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunlightAPI.OpenStates
{
    public class OpenStatesService : IOpenStatesService
    {
        private SunlightRestClient _sunlight;
        private const string host = "http://openstates.org/api/v1";

        public OpenStatesService(string api_key, string user_agent = "")
        {
            _sunlight = new SunlightRestClient(host, api_key, user_agent);
        }

        public async Task<IEnumerable<MetaData>> GetMetaData()
        {
            return await _sunlight.Get<IEnumerable<MetaData>>("metadata", new Dictionary<string,object>()); // this is the one method we call without params - make sure we get the overload that adds the api key
        }

        public async Task<MetaData> GetMetaData(string state)
        {
            var parms = new Dictionary<string, object>();

            return await _sunlight.Get<MetaData>("metadata/" + state, parms);
        }

        public async Task<IEnumerable<Bill>> FindBills(string state, BillSearchParams parms, string query = null)
        {
            var p = new Dictionary<string, object>();
            p.Add("state", state);
            p.Add("q", query);
            p.AddProperties(parms);

            return await _sunlight.Get<IEnumerable<Bill>>("bills", p);
        }

        public async Task<Bill> GetBill(string state, string session, string bill_id)
        {
            var p = new Dictionary<string, object>();

            return await _sunlight.Get<Bill>(string.Format("bills/{0}/{1}/{2}", state, session, bill_id), p);
        }

        public async Task<IEnumerable<Legislator>> FindLegislators(string state, LegislatorSearchParams parms = null)
        {
            var p = new Dictionary<string, object>();
            p.Add("state", state);
            p.AddProperties(parms);

            return await _sunlight.Get<IEnumerable<Legislator>>("legislators", p);
        }

        public async Task<IEnumerable<Legislator>> LocateLegislators(double lat, double lon)
        {
            var p = new Dictionary<string, object>();
            p.Add("lat", lat);
            p.Add("long", lon);

            return await _sunlight.Get<IEnumerable<Legislator>>("legislators/geo", p);
        }

        public async Task<Legislator> GetLegislator(string legislator_id)
        {
            var p = new Dictionary<string, object>();

            return await _sunlight.Get<Legislator>("legislators/" + legislator_id, p);
        }

        public async Task<IEnumerable<Committee>> FindCommittees(string state, string chamber = null, bool? committee = null, bool? subcommittee = null)
        {
            var p = new Dictionary<string, object>();
            p.Add("state", state);
            p.Add("chamber", chamber);
            p.Add("committee", committee);
            p.Add("subcommittee", subcommittee);

            return await _sunlight.Get<IEnumerable<Committee>>("committees", p);
        }

        public async Task<Committee> GetCommittee(string committee_id)
        {
            var p = new Dictionary<string, object>();

            return await _sunlight.Get<Committee>("committees/" + committee_id, p);
        }

        public async Task<IEnumerable<Event>> FindEvents(string state, string type = null)
        {
            var p = new Dictionary<string, object>();
            p.Add("state", state);
            p.Add("type", type);

            return await _sunlight.Get<IEnumerable<Event>>("events", p);
        }

        public async Task<IEnumerable<District>> FindDistricts(string state, string chamber)
        {
            var p = new Dictionary<string, object>();
            
            return await _sunlight.Get<IEnumerable<District>>(string.Format("districts/{0}/{1}", state, chamber), p);
        }

        public async Task<DistrictBoundary> GetDistrictBoundary(string boundary_id)
        {
            var p = new Dictionary<string, object>();

            return await _sunlight.Get<DistrictBoundary>("districts/boundary/" + boundary_id, p);
        }
    }
}
