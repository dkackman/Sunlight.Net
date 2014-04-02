using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SunlightAPI.OpenStates;

namespace SunlightAPITests
{
    [TestClass]
    public class OpenStatesTests
    {
        private IOpenStatesService service;

        [TestInitialize]
        public void Init()
        {
            service = new OpenStatesService(APIKEY.Key, "Sunlight.NET unit tests");
        }

        [TestMethod]
        public async Task GetMetaData()
        {
            var result = await service.GetMetaData();

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Count() > 0);
        }

        [TestMethod]
        public async Task GetMetaDataByState()
        {
            var result = await service.GetMetaData("az");

            Assert.IsNotNull(result);
            Assert.AreEqual(result.abbreviation, "az");
        }

        [TestMethod]
        public async Task FindBills()
        {
            var parms = new BillSearchParams()
            {
                chamber = "upper",
                status = "passed_upper"
            };

            var result = await service.FindBills("mn", parms);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetBill()
        {
            var result = await service.GetBill("mn", "2013s1", "SF 1");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task FindLegislators()
        {
            var service = new OpenStatesService(APIKEY.Key);
            var result = await service.FindLegislators("mn");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task LocateLegislators()
        {
            var result = await service.LocateLegislators(44.926868, -93.214049);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public async Task GetLegislator()
        {
            var result = await service.GetLegislator("MNL000333");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task FindCommittees()
        {
            var result = await service.FindCommittees("mn");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetCommittee()
        {
            var result = await service.GetCommittee("MNC000088");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task FindEvents()
        {
            var result = await service.FindEvents("mn");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task FindDistricts()
        {
            var service = new OpenStatesService(APIKEY.Key);
            var result = await service.FindDistricts("mn", "upper");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetDistrictBoundary()
        {
            var result = await service.GetDistrictBoundary("sldu/mn-66");

            Assert.IsNotNull(result);
        }
    }
}
