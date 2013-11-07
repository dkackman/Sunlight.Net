using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace SunlightAPI.CapitolWords
{
    public class SearchParameters
    {
        public SearchParameters()
        {
            Date = DateTime.MinValue;
            Start = DateTime.MinValue;
            End = DateTime.MinValue;
        }

        public int mincount { get; set; }

        public string state { get; set; }

        public string party { get; set; }

        public string chamber { get; set; }

        public DateTime Date { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
