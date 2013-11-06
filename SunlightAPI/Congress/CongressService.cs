using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunlightAPI.Congress
{
    public class CongressService : ICongressService
    {
        private SunlightRestClient _service;
        private const string host = "http://congress.api.sunlightfoundation.com";

        public CongressService(string api_key, string user_agent = "")
        {
            _service = new SunlightRestClient(host, api_key, user_agent);
        }

        public async Task<Results<Legislator>> LocateLegislators(double lat, double lon)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("latitude", lat);
            parms.Add("longitude", lon);

            return await _service.Get<Results<Legislator>>("/legislators/locate", parms);
        }

        public async Task<Results<Legislator>> LocateLegislators(string zip)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("zip", zip);

            return await _service.Get<Results<Legislator>>("/legislators/locate", parms);
        }

        public async Task<Results<Legislator>> FindLegislators(string query = null, Legislator searchPrototype = null)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("query", query);
            parms.AddSearchableProperties(searchPrototype);

            return await _service.Get<Results<Legislator>>("/legislators", parms);
        }

        public async Task<Results<District>> LocateDistricts(double lat, double lon)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("latitude", lat);
            parms.Add("longitude", lon);

            return await _service.Get<Results<District>>("/districts/locate", parms);
        }

        public async Task<Results<District>> LocateDistricts(string zip)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("zip", zip);

            return await _service.Get<Results<District>>("/districts/locate", parms);
        }

        public async Task<Results<Committee>> FindCommittees(string query = null, Committee searchPrototype = null)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("query", query);
            parms.AddSearchableProperties(searchPrototype);

            return await _service.Get<Results<Committee>>("/committees", parms);
        }

        public async Task<Results<Bill>> FindBills(string query = null, Bill searchPrototype = null)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("query", query);
            parms.AddSearchableProperties(searchPrototype);

            return await _service.Get<Results<Bill>>("/bills", parms);
        }

        public async Task<Results<Bill>> SearchBills(string query = null, bool highlight = false, Bill searchPrototype = null)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("query", query);
            parms.Add("highlight", highlight);
            parms.AddSearchableProperties(searchPrototype);

            return await _service.Get<Results<Bill>>("/bills/search", parms);
        }

        public async Task<Results<Vote>> FindVotes(string query = null, Vote searchPrototype = null)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("query", query);
            parms.AddSearchableProperties(searchPrototype);

            return await _service.Get<Results<Vote>>("/votes", parms);
        }

        public async Task<Results<FloorUpdate>> FindFloorUpdates(string query = null, FloorUpdate searchPrototype = null)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("query", query);
            parms.AddSearchableProperties(searchPrototype);

            return await _service.Get<Results<FloorUpdate>>("/floor_updates", parms);
        }

        public async Task<Results<Hearing>> FindHearings(string query = null, Hearing searchPrototype = null)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("query", query);
            parms.AddSearchableProperties(searchPrototype);

            return await _service.Get<Results<Hearing>>("/hearings", parms);
        }

        public async Task<Results<UpcomingBill>> FindUpcomingBills(string query = null, UpcomingBill searchPrototype = null)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("query", query);
            parms.AddSearchableProperties(searchPrototype);

            return await _service.Get<Results<UpcomingBill>>("/upcoming_bills", parms);
        }
    }
}
