using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.OpenStates
{
    public class Role
    {
        public string term { get; set; }
        public object end_date { get; set; }
        public string district { get; set; }
        public string chamber { get; set; }
        public string state { get; set; }
        public string party { get; set; }
        public string type { get; set; }
        public object start_date { get; set; }
        public string committee_id { get; set; }
        public string committee { get; set; }
        public string position { get; set; }
    }
}

