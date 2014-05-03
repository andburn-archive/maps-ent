using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapsAgo.Domain;
using MapsAgo.Domain.Freebase;
using System.Collections.Generic;

namespace MapsAgo.Tests.Domain
{
    [TestClass]
    public class TestFreebaseStrategy
    {
        private IGatheringStrategy Strategy;
        private InfoGatherer Gatherer;

        [TestInitialize]
        public void Initialize()
        {
            Strategy = new FreebaseStrategy();
            Gatherer = new InfoGatherer(Strategy);
        }

        [TestMethod]
        public void Test_Freebase_Search_Results()
        {
            IList<ISearchResult> results = Gatherer.Search(
                "hastings", "(all type:/military/military_conflict)");

            Assert.IsTrue(results.Count == 10);
        }

        [TestMethod]
        public void Test_Freebase_Details_Results()
        {
            IDataResource results = Gatherer.Details("/m/0c55s");

            Assert.IsTrue(results.EventName == "Battle of Hastings");
        }
    }
}
