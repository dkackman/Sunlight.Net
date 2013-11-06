using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.PoliticalPartyTime
{
    public class Venue
    {
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public int id { get; set; }
        public string resource_uri { get; set; }
        public string state { get; set; }
        public string venue_name { get; set; }
        public string zipcode { get; set; }
    }
}
