using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.OpenStates
{
    public class Participant
    {
        public string chamber { get; set; }
        public string participant_type { get; set; }
        public string participant { get; set; }
        public object id { get; set; }
        public string type { get; set; }
    }

    public class Event
    {
        public List<object> documents { get; set; }
        public object end { get; set; }
        public string description { get; set; }
        public List<Participant> participants { get; set; }
        public string created_at { get; set; }
        public string when { get; set; }
        public string updated_at { get; set; }
        public List<Source> sources { get; set; }
        public string state { get; set; }
        public string session { get; set; }
        public string location { get; set; }
        public List<object> related_bills { get; set; }
        public string timezone { get; set; }
        public string type { get; set; }
        public string id { get; set; }
        public string chamber { get; set; }
    }
}
