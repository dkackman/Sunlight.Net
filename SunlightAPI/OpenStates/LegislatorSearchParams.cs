using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.OpenStates
{
    public class LegislatorSearchParams
    {
        public string chamber { get; set; }
        public bool? active { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string term { get; set; }
        public string district { get; set; }
        public string party { get; set; }
    }
}
