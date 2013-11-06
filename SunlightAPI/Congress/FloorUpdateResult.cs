using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.Congress
{
    public class FloorUpdateResult
    {
        [SearchableProperty]
        public string chamber { get; set; }

        [SearchableProperty]
        public int congress { get; set; }

        [SearchableProperty]
        public string legislative_day { get; set; }
        public string timestamp { get; set; }
        public string update { get; set; }

        [SearchableProperty]
        public List<string> bill_ids { get; set; }

        [SearchableProperty]
        public List<string> roll_ids { get; set; }

        [SearchableProperty]
        public List<string> legislator_ids { get; set; }

        [SearchableProperty]
        public int year { get; set; }
    }
}
