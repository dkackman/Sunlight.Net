using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.OpenStates
{
    public class Office
    {
        public string fax { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string type { get; set; }
        public string email { get; set; }
    }

    public class Legislator
    {
        public string last_name { get; set; }
        public string updated_at { get; set; }
        public string full_name { get; set; }
        public string id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string district { get; set; }
        public string office_address { get; set; }
        public string state { get; set; }
        public string votesmart_id { get; set; }
        public string party { get; set; }
        public string csrfmiddlewaretoken { get; set; }
        public string email { get; set; }
        public string leg_id { get; set; }
        public bool active { get; set; }
        public string transparencydata_id { get; set; }
        public string nickname { get; set; }
        public string photo_url { get; set; }
        public string level { get; set; }
        public string url { get; set; }
        public string country { get; set; }
        public string created_at { get; set; }
        public string chamber { get; set; }
        public List<Office> offices { get; set; }
        public string office_phone { get; set; }
        public string suffixes { get; set; }
        public List<Source> sources { get; set; }
      //  public List<Role> old_roles { get; set; } - sunlight serializes these with the date range as the property names - won't deserialize
        public string boundary_id { get; set; }
        public List<Role> roles { get; set; }
    }
}
