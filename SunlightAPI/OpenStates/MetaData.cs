using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.OpenStates
{
    public class Upper
    {
        public string name { get; set; }
        public string title { get; set; }
    }

    public class Lower
    {
        public string name { get; set; }
        public string title { get; set; }
    }

    public class Chambers
    {
        public Upper upper { get; set; }
        public Lower lower { get; set; }
    }

    public class MetaData
    {
        public string lower_chamber_name { get; set; }
        public string lower_chamber_title { get; set; }
        public List<string> feature_flags { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string upper_chamber_title { get; set; }
        public string upper_chamber_name { get; set; }
        public Chambers chambers { get; set; }
    }
}
