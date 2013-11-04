using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.Congress
{
    public enum ComitteeChamberType
    {
        Null,
        house,
        senate,
        joint
    }

    public interface ICongressService
    {
        Task<Results<LegislatorResult>> FindLegislators(double lat, double lon);
        Task<Results<LegislatorResult>> FindLegislators(string zip);
        Task<Results<LegislatorResult>> FindLegislators(string query = null, LegislatorQueryParams parms = null);

        Task<Results<DistrictResult>> FindDistricts(double lat, double lon);
        Task<Results<DistrictResult>> FindDistricts(string zip);

        Task<Results<CommitteeResult>> FindCommittees(string query = null, CommitteeQueryParams parms = null);
    }
}
