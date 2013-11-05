using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.Congress
{
    public class CommitteeResult
    {
        public string chamber { get; set; }
        public string committee_id { get; set; }
        public string name { get; set; }
        public string parent_committee_id { get; set; }
        public bool? subcommittee { get; set; }
        public string member_ids { get; set; }

    }
}
