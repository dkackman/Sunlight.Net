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

        Task<FilterResults<Event>> FindEvents(DateTime start_date__gt, string beneficiaries__crp_id = null, string host__id = null, string beneficiaries__state = null);

        Task<Event> GetEvent(string id);

        Task<FilterResults<Beneficiary>> FindLegislators(string crp_id = null);

        Task<Beneficiary> GetLegislator(string id);

        Task<FilterResults<Host>> GetHosts();

        Task<Host> GetHost(string id);
    }
}
