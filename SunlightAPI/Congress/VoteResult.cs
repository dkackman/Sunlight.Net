using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.Congress
{
    public class VoteResult
    {
        public string chamber { get; set; }
        public int congress { get; set; }
        public string nomination_id { get; set; }
        public int number { get; set; }
        public string question { get; set; }
        public string required { get; set; }
        public string result { get; set; }
        public string roll_id { get; set; }
        public string roll_type { get; set; }
        public string source { get; set; }
        public string url { get; set; }
        public string vote_type { get; set; }
        public string voted_at { get; set; }
        public int year { get; set; }
    }
}
