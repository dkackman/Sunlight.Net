﻿using System;
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

        public async Task<Results<LegislatorResult>> LocateLegislators(double lat, double lon)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("latitude", lat);
            parms.Add("longitude", lon);

            return await _service.Get<Results<LegislatorResult>>("/legislators/locate", parms);
        }

        public async Task<Results<LegislatorResult>> LocateLegislators(string zip)
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

        public async Task<Results<DistrictResult>> LocateDistricts(double lat, double lon)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("latitude", lat);
            parms.Add("longitude", lon);

            return await _service.Get<Results<DistrictResult>>("/districts/locate", parms);
        }

        public async Task<Results<DistrictResult>> LocateDistricts(string zip)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("zip", zip);

            return await _service.Get<Results<DistrictResult>>("/districts/locate", parms);
        }

        public async Task<Results<CommitteeResult>> FindCommittees(string query = null, CommitteeResult searchPrototype = null)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("query", query);
            parms.AddSearchableProperties(searchPrototype);

            return await _service.Get<Results<CommitteeResult>>("/committees", parms);
        }

        public async Task<Results<BillResult>> FindBills(string query = null, BillResult searchPrototype = null)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("query", query);
            parms.AddSearchableProperties(searchPrototype);

            return await _service.Get<Results<BillResult>>("/bills", parms);
        }

        public async Task<Results<BillResult>> SearchBills(string query = null, bool highlight = false, BillResult searchPrototype = null)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("query", query);
            parms.Add("highlight", highlight);
            parms.AddSearchableProperties(searchPrototype);

            return await _service.Get<Results<BillResult>>("/bills/search", parms);
        }

        public async Task<Results<VoteResult>> FindVotes(string query = null, VoteResult searchPrototype = null)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("query", query);
            parms.AddSearchableProperties(searchPrototype);

            return await _service.Get<Results<VoteResult>>("/votes", parms);
        }

        public async Task<Results<FloorUpdateResult>> FindFloorUpdates(string query = null, FloorUpdateResult searchPrototype = null)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("query", query);
            parms.AddSearchableProperties(searchPrototype);

            return await _service.Get<Results<FloorUpdateResult>>("/floor_updates", parms);
        }

        public async Task<Results<HearingResult>> FindHearings(string query = null, HearingResult searchPrototype = null)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("query", query);
            parms.AddSearchableProperties(searchPrototype);

            return await _service.Get<Results<HearingResult>>("/hearings", parms);
        }

        public async Task<Results<UpcomingBillResult>> FindUpcomingBills(string query = null, UpcomingBillResult searchPrototype = null)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("query", query);
            parms.AddSearchableProperties(searchPrototype);

            return await _service.Get<Results<UpcomingBillResult>>("/upcoming_bills", parms);
        }
    }
}
