using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.PoliticalPartyTime
{
    public class FilterResults<T>
    {
        public MetaResult meta { get; set; }

        public List<T> objects { get; set; }
    }
}
