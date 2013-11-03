using System;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SunlightAPI;
using SunlightAPI.PoliticalPartyTime;

namespace SunlightAPITests
{
    [TestClass]
    public class PolitcalPartyTimeTests
    {
        [TestMethod]
        public async Task SimpleFilterEventTest()
        {
            var service = new PoliticalPartyTimeService(APIKEY.Key);
            var result = await service.FilterEvents(new DateTime(2013, 1, 1));

            Assert.IsNotNull(result);
        }
    }
}
