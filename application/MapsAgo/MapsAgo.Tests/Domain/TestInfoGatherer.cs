using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapsAgo.Domain;
using System.Collections.Generic;

namespace MapsAgo.Tests.Domain
{
    [TestClass]
    public class TestInfoGatherer
    {
        private IGatheringStrategy Strategy;
        private InfoGatherer Gatherer;

        [TestInitialize]
        public void Initialize() {
            Strategy = new MockStrategy();
            Gatherer = new InfoGatherer(Strategy);
        }

        [TestMethod]
        public void Test_Search_Results()
        {            
            IList<ISearchResult> results = Gatherer.Search("blah", "blah");

            Assert.AreEqual("/m/0c55s", results[0].Id);
            Assert.AreEqual("Battle of Little Bighorn", results[1].Name);
        }

        [TestMethod]
        public void Test_Details_Results()
        {
            IDataResource resource = Gatherer.Details("foo");

            Assert.AreEqual(0, resource.EventEndYear);
        }

    }
}
