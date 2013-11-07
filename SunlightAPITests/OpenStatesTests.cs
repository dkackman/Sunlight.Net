using System;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SunlightAPI.OpenStates;

namespace SunlightAPITests
{
    [TestClass]
    public class OpenStatesTests
    {
        [TestMethod]
        public async Task GetMetaData()
        {
            var service = new OpenStatesService(APIKEY.Key);
            var result = await service.GetMetaData();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetMetaDataByState()
        {
            var service = new OpenStatesService(APIKEY.Key);
            var result = await service.GetMetaData("mn");

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public async Task FindBills()
        {
            var service = new OpenStatesService(APIKEY.Key);
            var result = await service.FindBills();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetBill()
        {
            var service = new OpenStatesService(APIKEY.Key);
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
            var service = new OpenStatesService(APIKEY.Key);
            var result = await service.LocateLegislators(44.926868, -93.214049);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetLegislator()
        {
            var service = new OpenStatesService(APIKEY.Key);
            var result = await service.GetLegislator("MNL000333");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task FindCommittees()
        {
            var service = new OpenStatesService(APIKEY.Key);
            var result = await service.FindCommittees("mn");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetCommittee()
        {
            var service = new OpenStatesService(APIKEY.Key);
            var result = await service.GetCommittee("MNC000088");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task FindEvents()
        {
            var service = new OpenStatesService(APIKEY.Key);
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
            var service = new OpenStatesService(APIKEY.Key);
            var result = await service.GetDistrictBoundary( "sldu/mn-66");

            Assert.IsNotNull(result);
        }

    }
}
