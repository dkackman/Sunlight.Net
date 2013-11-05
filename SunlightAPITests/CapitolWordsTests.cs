using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SunlightAPI;
using SunlightAPI.CapitolWords;

namespace SunlightAPITests
{
    [TestClass]
    public class CapitolWordsTests
    {
        [TestMethod]
        public async Task GetSinglePageOfWords()
        {
            var service = new CapitolWordsService(APIKEY.Key, "Sunlight.NET unit tests");
            var phrases = await service.GetTopPhrasesByState("mn", 2);
            Assert.IsTrue(phrases.Count() > 0);
        }

        [TestMethod]
        public async Task GetMultiplePagesOfWords()
        {
            var service = new CapitolWordsService(APIKEY.Key, "Sunlight.NET unit tests");
            var paging = new PagingState(100);

            DateTime date = new DateTime(2013, 1, 1); // this date seems to return many pages
            var phrases = await service.GetTopPhrasesByDate(date, 1, paging);

            while (paging.Advance(phrases.Count()))
            {
                var phrase1 = phrases.FirstOrDefault();
                phrases = await service.GetTopPhrasesByDate(date, 1, paging);
                var phrase2 = phrases.FirstOrDefault();
                Assert.AreNotEqual(phrase1, phrase2);
            }

            Assert.IsTrue(paging.Page > 2);
        }

        [TestMethod]
        public async Task FullTextSearchSimpleTest()
        {
            var service = new CapitolWordsService(APIKEY.Key, "Sunlight.NET unit tests");
            var parms = new SearchParameters()
            {
                Date = new DateTime(2013, 1, 1)
            };
            var results = await service.FullTextSearch("health", searchParams: parms);
            Assert.IsNotNull(results);
            Assert.IsTrue(results.num_found > 0);
            Assert.IsNotNull(results.results);
            Assert.IsTrue(results.results.Count() > 0);
        }
        
        [TestMethod]
        public async Task SimpleTimeSeriesTest()
        {
            var service = new CapitolWordsService(APIKEY.Key, "Sunlight.NET unit tests");
            var parms = new SearchParameters()
            {
                Date = new DateTime(2013, 1, 1)
            };
            var results = await service.GetPhraseTimeSeriesByYear("health");
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count() > 0);
        }       
        
        [TestMethod]
        public async Task SimpleTopEntityByPhraseTest()
        {
            var service = new CapitolWordsService(APIKEY.Key, "Sunlight.NET unit tests");

            var results = await service.GetTopLegislatorByPhrase("health");
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count() > 0);
        }
    }
}
