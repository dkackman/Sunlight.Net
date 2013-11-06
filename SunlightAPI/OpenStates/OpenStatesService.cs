using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.OpenStates
{
    public class OpenStatesService : IOpenStatesService
    {
        private SunlightRestClient _service;
        private const string host = "http://openstates.org/api/v1";

        public OpenStatesService(string api_key, string user_agent = "")
        {
            _service = new SunlightRestClient(host, api_key, user_agent);
        }
    }
}
