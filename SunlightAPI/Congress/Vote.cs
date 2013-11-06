using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.Congress
{
    public class Vote
    {
        [SearchableProperty]
        public string chamber { get; set; }

        [SearchableProperty]
        public int congress { get; set; }
        public string nomination_id { get; set; }

        [SearchableProperty]
        public int number { get; set; }
        public string question { get; set; }

        [SearchableProperty]
        public string required { get; set; }

        [SearchableProperty]
        public string result { get; set; }

        [SearchableProperty]
        public string bill_id { get; set; }

        [SearchableProperty]
        public string roll_id { get; set; }

        [SearchableProperty]
        public string roll_type { get; set; }
        public string source { get; set; }
        public string url { get; set; }

        [SearchableProperty]
        public string vote_type { get; set; }

        [SearchableProperty]
        public string voted_at { get; set; }

        [SearchableProperty]
        public int year { get; set; }
    }
}
