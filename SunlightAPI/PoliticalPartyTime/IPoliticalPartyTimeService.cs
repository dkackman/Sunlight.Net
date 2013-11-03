using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.PoliticalPartyTime
{
    interface IPoliticalPartyTimeService
    {
        Task<T> GetNext<T>(string request) where T : class;

        Task<FilterResults> FilterEvents(DateTime start_date__gt, string beneficiaries__crp_id = null, string host__id = null, string beneficiaries__state = null);

        Task<EventResult> GetEventById(string id);
    }
}
