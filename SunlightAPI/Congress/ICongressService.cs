using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.Congress
{
    public interface ICongressService
    {
        Task<Results<Legislator>> LocateLegislators(double lat, double lon);
        Task<Results<Legislator>> LocateLegislators(string zip);
        Task<Results<Legislator>> FindLegislators(string query = null, Legislator searchPrototype = null);

        Task<Results<District>> LocateDistricts(double lat, double lon);
        Task<Results<District>> LocateDistricts(string zip);

        Task<Results<Committee>> FindCommittees(string query = null, Committee searchPrototype = null);

        Task<Results<Bill>> FindBills(string query = null, Bill searchPrototype = null);
        Task<Results<Bill>> SearchBills(string query = null, bool highlight = false, Bill searchPrototype = null);

        Task<Results<Vote>> FindVotes(string query = null, Vote searchPrototype = null);
        Task<Results<FloorUpdate>> FindFloorUpdates(string query = null, FloorUpdate searchPrototype = null);

        Task<Results<Hearing>> FindHearings(string query = null, Hearing searchPrototype = null);

        Task<Results<UpcomingBill>> FindUpcomingBills(string query = null, UpcomingBill searchPrototype = null);
    }
}
