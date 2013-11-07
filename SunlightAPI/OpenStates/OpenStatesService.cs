using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.OpenStates
{
    public class OpenStatesService : IOpenStatesService
    {
        private SunlightRestClient _service;
        private const string host = "http://openstates.org/api/v1";

        public OpenStatesService(string api_key, string user_agent = "")
        {
            _service = new SunlightRestClient(host, api_key, user_agent);
        }

        public async Task<IEnumerable<MetaData>> GetMetaData()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MetaData>> GetMetaData(string state)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Bill>> FindBills(string query = null, BillSearchParams parms = null)
        {
            throw new NotImplementedException();
        }

        public async Task<Bill> GetBill(string state, string session, string bill_id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Legislator>> FindLegislators(string state, LegislatorSearchParams parms = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Legislator>> LocateLegislators(double lat, double lon)
        {
            throw new NotImplementedException();
        }

        public async Task<Legislator> GetLegislator(string legislator_id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Committee>> FindCommittees(string state, string chamber = null, bool? committee = null, bool? subcommittee = null)
        {
            throw new NotImplementedException();
        }

        public async Task<Committee> GetCommittee(string committee_id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Event>> FindEvents(string state, string type = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<District>> FindDistricts(string state, string chamber)
        {
            throw new NotImplementedException();
        }

        public async Task<DistrictBoundary> GetDistrictBoundary(string boundary_id)
        {
            throw new NotImplementedException();
        }
    }
}
