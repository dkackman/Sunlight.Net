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
            mincount = -1;
            state = null;
            party = party.unknown;
            chamber = chamber.unknown;
            Date = DateTime.MinValue;
            Start = DateTime.MinValue;
            End = DateTime.MinValue;
        }

        public int mincount { get; set; }

        public string state { get; set; }

        public party party { get; set; }

        public chamber chamber { get; set; }

        public DateTime Date { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        internal void GetParameters(IDictionary<string,object> parms)
        {
            if (mincount > 0)
                parms.Add("mincount", mincount);

            if (state != null)
                parms.Add("state", state);

            if (party != party.unknown)
                parms.Add("party", party);

            if (chamber != chamber.unknown)
                parms.Add("chamber", chamber);

            if (Date != DateTime.MinValue)
                parms.Add("date", Date.ToString("yyyy-MM-dd"));

            if (Start != DateTime.MinValue)
                parms.Add("start_date", Start.ToString("yyyy-MM-dd"));

            if (End != DateTime.MinValue)
                parms.Add("end_date", End.ToString("yyyy-MM-dd"));
        }
    }
}
