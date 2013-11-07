using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.OpenStates
{
    public class LegislatorRef
    {
        public string leg_id { get; set; }
        public string full_name { get; set; }
    }

    public class District
    {
        public List<LegislatorRef> legislators { get; set; }
        public string name { get; set; }
        public string chamber { get; set; }
        public string abbr { get; set; }
        public string boundary_id { get; set; }
        public int num_seats { get; set; }
        public string id { get; set; }
    }
}
