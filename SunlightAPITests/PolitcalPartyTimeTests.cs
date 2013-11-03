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

        [TestMethod]
        public async Task PageFilterEvents()
        {
            var service = new PoliticalPartyTimeService(APIKEY.Key);
            var result = await service.FilterEvents(new DateTime(2013, 1, 1));
            Assert.IsNotNull(result.meta);

            var next = await service.GetNext<FilterResults>(result.meta.next);
            Assert.IsNotNull(next);
            Assert.IsNotNull(next.meta);

            Assert.AreNotEqual(result.meta, next.meta);
        }

        [TestMethod]
        public async Task TestEventById()
        {
            var service = new PoliticalPartyTimeService(APIKEY.Key);
            var result = await service.GetEventById("31");

            Assert.IsNotNull(result);
        }
    }
}
