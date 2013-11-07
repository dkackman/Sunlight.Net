using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.OpenStates
{
    public interface IOpenStatesService
    {
        Task<IEnumerable<MetaData>> GetMetaData();
        Task<MetaData> GetMetaData(string state);
        
        Task<IEnumerable<Bill>> FindBills(string state, BillSearchParams parms, string query = null);
        Task<Bill> GetBill(string state, string session, string bill_id);

        Task<IEnumerable<Legislator>> FindLegislators(string state, LegislatorSearchParams parms = null);
        Task<IEnumerable<Legislator>> LocateLegislators(double lat, double lon);
        Task<Legislator> GetLegislator(string legislator_id);

        Task<IEnumerable<Committee>> FindCommittees(string state, string chamber = null, bool? committee =null, bool? subcommittee = null);
        Task<Committee> GetCommittee(string committee_id);


        Task<IEnumerable<Event>> FindEvents(string state, string type = null);

        Task<IEnumerable<District>> FindDistricts(string state, string chamber);

        Task<DistrictBoundary> GetDistrictBoundary(string boundary_id);
    }
}
