using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.Congress
{
    public enum title
    {
        Null,
        Sen,
        Rep,
        Del,
        Con
    }
    public enum chamber
    {
        Null,
        senate,
        house
    }

    public enum party
    {
        Null,
        R,
        D,
        I
    }

    public enum gender
    {
        Null,
        M,
        F
    }
    public class LegislatorQueryParams
    {
        public title title { get; set; }
        public chamber chamber { get; set; }
        public string first_name { get; set; }
        public string nickname { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string name_suffix { get; set; }
        public party party { get; set; }
        public string state { get; set; }
        public string state_name { get; set; }
        public string district { get; set; }
        public bool? in_office { get; set; }
        public gender gender { get; set; }
        public string birthdate { get; set; }
        public string term_start { get; set; }
        public string term_end { get; set; }
        public int senate_class { get; set; }
        public string bioguide_id { get; set; }
        public string thomas_id { get; set; }
        public string lis_id { get; set; }
        public string votesmart_id { get; set; }
        public string fec_ids { get; set; }
        public string govtrack_id { get; set; }
        public string crp_id { get; set; }
    }
}
