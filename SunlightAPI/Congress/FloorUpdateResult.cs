using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.Congress
{
    public class FloorUpdateResult
    {
        public string chamber { get; set; }
        public int congress { get; set; }
        public string legislative_day { get; set; }
        public string timestamp { get; set; }
        public string update { get; set; }
        public List<string> bill_ids { get; set; }
        public List<string> roll_ids { get; set; }
        public List<string> legislator_ids { get; set; }
    }
}
