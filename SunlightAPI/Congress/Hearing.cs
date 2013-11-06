using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.Congress
{
    public class Hearing
    {
        [SearchableProperty]
        public string chamber { get; set; }

        [SearchableProperty]
        public string committee_id { get; set; }

        [SearchableProperty]
        public int congress { get; set; }
        public string occurs_at { get; set; }
        public string room { get; set; }
        public string description { get; set; }

        [SearchableProperty]
        public bool? dc { get; set; }

        [SearchableProperty]
        public List<string> bill_ids { get; set; }
        public string url { get; set; }

        [SearchableProperty]
        public string hearing_type { get; set; }
    }
}
