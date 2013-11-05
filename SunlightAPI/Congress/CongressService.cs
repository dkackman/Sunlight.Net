using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<Results<LegislatorResult>> FindLegislators(double lat, double lon)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("latitude", lat);
            parms.Add("longitude", lon);

            return await _service.Get<Results<LegislatorResult>>("/legislators/locate", parms);
        }

        public async Task<Results<LegislatorResult>> FindLegislators(string zip)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("zip", zip);

            return await _service.Get<Results<LegislatorResult>>("/legislators/locate", parms);
        }

        public async Task<Results<LegislatorResult>> FindLegislators(string query = null, LegislatorResult searchPrototype = null)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("query", query);
            parms.AddSearchableProperties(searchPrototype);

            return await _service.Get<Results<LegislatorResult>>("/legislators", parms);
        }

        public async Task<Results<DistrictResult>> FindDistricts(double lat, double lon)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("latitude", lat);
            parms.Add("longitude", lon);

            return await _service.Get<Results<DistrictResult>>("/districts/locate", parms);
        }

        public async Task<Results<DistrictResult>> FindDistricts(string zip)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("zip", zip);

            return await _service.Get<Results<DistrictResult>>("/districts/locate", parms);
        }

        public async Task<Results<CommitteeResult>> FindCommittees(string query = null, CommitteeResult searchPrototype = null)
        {
            throw new NotImplementedException();
        }

        public async Task<Results<BillResult>> FindBills(string query = null, BillResult searchPrototype = null)
        {
            throw new NotImplementedException();
        }

        public async Task<Results<BillResult>> SearchBills(string query = null, BillResult searchPrototype = null)
        {
            throw new NotImplementedException();
        }

        public async Task<Results<VoteResult>> FindVotes(string query = null, VoteResult searchPrototype = null)
        {
            throw new NotImplementedException();
        }

        public async Task<Results<FloorUpdateResult>> FindFloorUpdaste(string query = null, FloorUpdateResult searchPrototype = null)
        {
            throw new NotImplementedException();
        }

        public async Task<Results<HearingResult>> FindHearings(string query = null, HearingResult searchPrototype = null)
        {
            throw new NotImplementedException();
        }
    }
}
