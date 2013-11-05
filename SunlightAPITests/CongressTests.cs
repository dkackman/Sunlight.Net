using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SunlightAPI.Congress;

namespace SunlightAPITests
{
    [TestClass]
    public class CongressTests
    {
        [TestMethod]
        public async Task FindLegislatorByZip()
        {
            var service = new CongressService(APIKEY.Key);
            var results = await service.FindLegislators("55116");

            Assert.IsNotNull(results);
            Assert.IsTrue(results.count > 0);
            Assert.IsTrue(results.results.Count > 0);
        }

        [TestMethod]
        public async Task FindLegislatorByLatLong()
        {
            var service = new CongressService(APIKEY.Key);
            var results = await service.FindLegislators(44.926868, -93.214049);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.count > 0);
            Assert.IsTrue(results.results.Count > 0);
        }
        [TestMethod]
        public async Task FindDistrictsByZip()
        {
            var service = new CongressService(APIKEY.Key);
            var results = await service.FindLegislators("55116");

            Assert.IsNotNull(results);
            Assert.IsTrue(results.count > 0);
            Assert.IsTrue(results.results.Count > 0);
        }

        [TestMethod]
        public async Task FindDistrictsByLatLong()
        {
            var service = new CongressService(APIKEY.Key);
            var results = await service.FindLegislators(44.926868, -93.214049);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.count > 0);
            Assert.IsTrue(results.results.Count > 0);
        }
    }
}
