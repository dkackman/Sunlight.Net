using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.Congress
{
    public interface ICongressService
    {
        Task<Results<LegislatorResult>> LocateLegislators(double lat, double lon);
        Task<Results<LegislatorResult>> LocateLegislators(string zip);
        Task<Results<LegislatorResult>> FindLegislators(string query = null, LegislatorResult searchPrototype = null);

        Task<Results<DistrictResult>> LocateDistricts(double lat, double lon);
        Task<Results<DistrictResult>> LocateDistricts(string zip);

        Task<Results<CommitteeResult>> FindCommittees(string query = null, CommitteeResult searchPrototype = null);

        Task<Results<BillResult>> FindBills(string query = null, BillResult searchPrototype = null);
        Task<Results<BillResult>> SearchBills(string query = null, bool highlight = false, BillResult searchPrototype = null);

        Task<Results<VoteResult>> FindVotes(string query = null, VoteResult searchPrototype = null);
        Task<Results<FloorUpdateResult>> FindFloorUpdates(string query = null, FloorUpdateResult searchPrototype = null);

        Task<Results<HearingResult>> FindHearings(string query = null, HearingResult searchPrototype = null);

        Task<Results<UpcomingBillResult>> FindUpcomingBills(string query = null, UpcomingBillResult searchPrototype = null);
    }
}
