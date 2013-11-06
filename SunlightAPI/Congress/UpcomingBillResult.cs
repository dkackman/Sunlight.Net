using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.Congress
{
    public class UpcomingBillResult
    {
        [SearchableProperty]
        public string bill_id { get; set; }

        [SearchableProperty]
        public string source_type { get; set; }

        [SearchableProperty]
        public int congress { get; set; }

        [SearchableProperty]
        public string chamber { get; set; }

        [SearchableProperty]
        public string legislative_day { get; set; }

        [SearchableProperty]
        public string range { get; set; }
        public string url { get; set; }
        public string context { get; set; }
    }
}
