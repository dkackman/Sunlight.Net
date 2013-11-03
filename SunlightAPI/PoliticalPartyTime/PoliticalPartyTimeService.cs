using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.PoliticalPartyTime
{
    public class PoliticalPartyTimeService
    {
        private SunlightService _service;

        public PoliticalPartyTimeService(string api_key)
        {
            _service = new SunlightService("", api_key);
        }
    }
}
