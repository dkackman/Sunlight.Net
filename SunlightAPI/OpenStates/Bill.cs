using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.OpenStates
{
    public class Bill
    {
        public string title { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string id { get; set; }
        public string chamber { get; set; }
        public string state { get; set; }
        public string session { get; set; }
        public List<string> type { get; set; }
        public List<string> subjects { get; set; }
        public string bill_id { get; set; }
    }
}
