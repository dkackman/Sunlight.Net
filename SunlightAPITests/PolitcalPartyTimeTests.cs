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
            var service = new PoliticalPartyTimeService(APIKEY.Key, "Sunlight.NET unit tests");
            var result = await service.FilterEvents(new DateTime(2013, 1, 1));

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task PageFilterEvents()
        {
            var service = new PoliticalPartyTimeService(APIKEY.Key, "Sunlight.NET unit tests");
            var result = await service.FilterEvents(new DateTime(2013, 1, 1));
            Assert.IsNotNull(result.meta);

            var next = await service.GetNext<FilterResults<EventResult>>(result.meta.next);
            Assert.IsNotNull(next);
            Assert.IsNotNull(next.meta);

            Assert.AreNotEqual(result.meta, next.meta);
        }

        [TestMethod]
        public async Task TestEventById()
        {
            var service = new PoliticalPartyTimeService(APIKEY.Key, "Sunlight.NET unit tests");
            var result = await service.GetEventById("31");

            Assert.IsNotNull(result);
            Assert.AreEqual(result.rsvp_info, "Rachel Bourassa; 202-223-8956; normandyrsvp@yahoo.com");
        }

        [TestMethod]
        public async Task GetHostsTest()
        {
            var service = new PoliticalPartyTimeService(APIKEY.Key, "Sunlight.NET unit tests");
            var result = await service.FilterEvents(new DateTime(2013, 1, 1));

            Assert.IsNotNull(result);
            Assert.IsTrue(result.objects.Count > 0);
        }

        [TestMethod]
        public async Task TestHostById()
        {
            var service = new PoliticalPartyTimeService(APIKEY.Key, "Sunlight.NET unit tests");
            var result = await service.GetHostById("19");

            Assert.IsNotNull(result);
            Assert.AreEqual(result.crp_id, "Y00000348220");
        }

        [TestMethod]
        public async Task SimpleFilterLegislatorTest()
        {
            var service = new PoliticalPartyTimeService(APIKEY.Key, "Sunlight.NET unit tests");
            var result = await service.FilterLegislators();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.objects.Count > 0);
        }

        [TestMethod]
        public async Task TestLegislatorById()
        {
            var service = new PoliticalPartyTimeService(APIKEY.Key, "Sunlight.NET unit tests");
            var result = await service.GetLegislatorById("12");

            Assert.IsNotNull(result);
            Assert.AreEqual(result.bioguide, "L000263");
        }
    }
}
