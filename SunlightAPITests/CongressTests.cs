using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SunlightAPI.Congress;

namespace SunlightAPITests
{
    [TestClass]
    public class CongressTests
    {
        private ICongressService service;

        [TestInitialize]
        public void Init()
        {
            service = new CongressService(APIKEY.Key, "Sunlight.NET unit tests");
        }
        
        [TestMethod]
        public async Task FindLegislatorByZip()
        {
            var results = await service.LocateLegislators("55116");

            Assert.IsNotNull(results);
            Assert.IsTrue(results.count > 0);
            Assert.IsTrue(results.results.Count > 0);
        }

        [TestMethod]
        public async Task FindLegislatorByLatLong()
        {
            var results = await service.LocateLegislators(44.926868, -93.214049);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.count > 0);
            Assert.IsTrue(results.results.Count > 0);
        }
        [TestMethod]
        public async Task FindDistrictsByZip()
        {
            var results = await service.LocateLegislators("55116");

            Assert.IsNotNull(results);
            Assert.IsTrue(results.count > 0);
            Assert.IsTrue(results.results.Count > 0);
        }

        [TestMethod]
        public async Task FindDistrictsByLatLong()
        {
            var results = await service.LocateLegislators(44.926868, -93.214049);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.count > 0);
            Assert.IsTrue(results.results.Count > 0);
        }

        [TestMethod]
        public async Task FindLegislators()
        {
            var results = await service.FindLegislators("");

            Assert.IsNotNull(results);
            Assert.IsTrue(results.count > 0);
            Assert.IsTrue(results.results.Count > 0);
        }

        [TestMethod]
        public async Task FindCommittees()
        {
            var results = await service.FindCommittees("");

            Assert.IsNotNull(results);
            Assert.IsTrue(results.count > 0);
            Assert.IsTrue(results.results.Count > 0);
        }

        [TestMethod]
        public async Task FindBills()
        {
            var results = await service.FindBills("");

            Assert.IsNotNull(results);
            Assert.IsTrue(results.count > 0);
            Assert.IsTrue(results.results.Count > 0);
        }

        [TestMethod]
        public async Task FindVotes()
        {
            var results = await service.FindVotes("");

            Assert.IsNotNull(results);
            Assert.IsTrue(results.count > 0);
            Assert.IsTrue(results.results.Count > 0);
        }

        [TestMethod]
        public async Task FindFloorUpdates()
        {
            var results = await service.FindFloorUpdates("");

            Assert.IsNotNull(results);
            Assert.IsTrue(results.count > 0);
            Assert.IsTrue(results.results.Count > 0);
        }

        [TestMethod]
        public async Task FindHearings()
        {
            var results = await service.FindHearings("");

            Assert.IsNotNull(results);
            Assert.IsTrue(results.count > 0);
            Assert.IsTrue(results.results.Count > 0);
        }

        [TestMethod]
        public async Task FindUpcomingBills()
        {
            var results = await service.FindUpcomingBills("");

            Assert.IsNotNull(results);
            Assert.IsTrue(results.count > 0);
            Assert.IsTrue(results.results.Count > 0);
        }
    }
}
