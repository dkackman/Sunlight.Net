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

        Task<FilterResults<Event>> FilterEvents(DateTime start_date__gt, string beneficiaries__crp_id = null, string host__id = null, string beneficiaries__state = null);

        Task<Event> GetEventById(string id);

        Task<FilterResults<Beneficiary>> FilterLegislators(string crp_id = null);

        Task<Beneficiary> GetLegislatorById(string id);

        Task<FilterResults<Host>> GetHosts();

        Task<Host> GetHostById(string id);
    }
}
