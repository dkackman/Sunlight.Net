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
         private IPoliticalPartyTimeService service;

         [TestInitialize]
         public void Init()
         {
             service = new PoliticalPartyTimeService(APIKEY.Key, "Sunlight.NET unit tests");
         }

        [TestMethod]
        public async Task SimpleFilterEventTest()
        {
            var result = await service.FindEvents(new DateTime(2013, 1, 1));

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task PageFilterEvents()
        {
            var result = await service.FindEvents(new DateTime(2013, 1, 1));
            Assert.IsNotNull(result.meta);

            var next = await service.GetNext<FilterResults<Event>>(result.meta.next);
            Assert.IsNotNull(next);
            Assert.IsNotNull(next.meta);

            Assert.AreNotEqual(result.meta, next.meta);
        }

        [TestMethod]
        public async Task TestEventById()
        {
            var result = await service.GetEvent("31");

            Assert.IsNotNull(result);
            Assert.AreEqual(result.rsvp_info, "Rachel Bourassa; 202-223-8956; normandyrsvp@yahoo.com");
        }

        [TestMethod]
        public async Task GetHostsTest()
        {
            var result = await service.FindEvents(new DateTime(2013, 1, 1));

            Assert.IsNotNull(result);
            Assert.IsTrue(result.objects.Count > 0);
        }

        [TestMethod]
        public async Task TestHostById()
        {
            var result = await service.GetHost("19");

            Assert.IsNotNull(result);
            Assert.AreEqual(result.crp_id, "Y00000348220");
        }

        [TestMethod]
        public async Task SimpleFilterLegislatorTest()
        {
            var result = await service.FindLegislators();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.objects.Count > 0);
        }

        [TestMethod]
        public async Task TestLegislatorById()
        {
            var result = await service.GetLegislator("12");

            Assert.IsNotNull(result);
            Assert.AreEqual(result.bioguide, "L000263");
        }
    }
}
