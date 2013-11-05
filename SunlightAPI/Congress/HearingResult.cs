using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.Congress
{
    public class HearingResult
    {
        public string chamber { get; set; }
        public string committee_id { get; set; }
        public int congress { get; set; }
        public string occurs_at { get; set; }
        public string room { get; set; }
        public string description { get; set; }
        public bool dc { get; set; }
        public List<string> bill_ids { get; set; }
        public string url { get; set; }
        public string hearing_type { get; set; }
    }
}
