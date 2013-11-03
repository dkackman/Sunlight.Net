using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.PoliticalPartyTime
{
    public class MetaResult : EquatableObject<MetaResult>
    {
        public int limit { get; set; }

        public string next { get; set; }

        public int offset { get; set; }

        public string previous { get; set; }

        public int total_count { get; set; }
    }
}
