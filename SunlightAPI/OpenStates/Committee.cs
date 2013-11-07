using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.OpenStates
{
    public class Committee
    {
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public object parent_id { get; set; }
        public string state { get; set; }
        public object subcommittee { get; set; }
        public string committee { get; set; }
        public string chamber { get; set; }
        public string id { get; set; }
    }
}
