using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.Congress
{
    public class CommitteeQueryParams
    {
        public string committee_id { get; set; }
        public ComitteeChamberType chamber { get; set; }
        public bool? subcommittee { get; set; }
        public string member_ids { get; set; }
        public string parent_committee_id { get; set; }
    }
}
