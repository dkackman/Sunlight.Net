using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SunlightAPI.OpenStates;

namespace SunlightAPITests
{
    [TestClass]
    public class OpenStatesTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var service = new OpenStatesService(APIKEY.Key);
        }
    }
}
