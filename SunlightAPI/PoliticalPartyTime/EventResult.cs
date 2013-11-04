using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.PoliticalPartyTime
{
    public class EventResult 
    {
        public List<BeneficiaryResult> beneficiaries { get; set; }
        public bool canceled { get; set; }
        public string checks_payable_to_address { get; set; }
        public string contributions_info { get; set; }
        public string distribution_paid_for_by { get; set; }
        public DateTime? end_date { get; set; }
        public string end_time { get; set; }
        public string entertainment { get; set; }
        public List<HostResult> hosts { get; set; }
        public int id { get; set; }
        public bool is_presidential { get; set; }
        public string make_checks_payable_to { get; set; }
        public string notes { get; set; }
        public bool postponed { get; set; }
        public string resource_uri { get; set; }
        public string rsvp_info { get; set; }
        public DateTime start_date { get; set; }
        public string start_time { get; set; }
        public VenueResult venue { get; set; }
    }
}
