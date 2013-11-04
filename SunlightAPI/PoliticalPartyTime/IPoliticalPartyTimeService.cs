using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.PoliticalPartyTime
{
    public interface IPoliticalPartyTimeService
    {
        Task<T> GetNext<T>(string request) where T : class;

        Task<FilterResults<EventResult>> FilterEvents(DateTime start_date__gt, string beneficiaries__crp_id = null, string host__id = null, string beneficiaries__state = null);

        Task<EventResult> GetEventById(string id);

        Task<FilterResults<BeneficiaryResult>> FilterLegislators(string crp_id = null);

        Task<BeneficiaryResult> GetLegislatorById(string id);

        Task<FilterResults<HostResult>> GetHosts();

        Task<HostResult> GetHostById(string id);
    }
}
