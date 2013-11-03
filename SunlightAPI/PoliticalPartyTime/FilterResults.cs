using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.PoliticalPartyTime
{
    public class FilterResults
    {
        public MetaResult meta { get; set; }

        public List<EventResult> objects { get; set; }
    }
}
