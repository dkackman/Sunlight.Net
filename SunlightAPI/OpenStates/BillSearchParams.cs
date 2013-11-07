using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.OpenStates
{
    public class BillSearchParams
    {
        public string state { get; set; }
        public string chamber { get; set; }
        public string subject { get; set; }
        public string status { get; set; }
        public string sponsor_id { get; set; }
        public string type { get; set; }
        public string bill_id { get; set; }
        public string bill_id__in { get; set; }
        public string search_window { get; set; }
        public string updated_since { get; set; }
        public string last_action_since { get; set; }
    }
}
