using NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchlistService.DataAccess;
using Moq;
using NUnit.Framework;

namespace WatchlistService.Tests.Repository
{
    [TestFixture]
    public class TestWatchlistRepository
    {
        private WatchlistService.Services.WatchlistRepository reposToTest = null;
        private Mock<IWatchlistDataProvider> watchlistProviderDependency = null;

        [SetUp]
        public void SetUp()
        {
            watchlistProviderDependency = new Mock<IWatchlistDataProvider>();
            reposToTest = new Services.WatchlistRepository(watchlistProviderDependency.Object);
        }

        [Category("Watchlist repository test")]
        [Test]
        public void Test_GetWatchlists_ShouldReturnGoodResults()
        {
            int numofLists = 2;
            var testList = WatchlistTestDataHelper.CreateXWatchlists(numofLists);

            watchlistProviderDependency.Setup(x => x.GetInvestorWatchlists(It.IsAny<int>())).Returns(testList);
            var retLists = reposToTest.GetWatchlists(It.IsAny<int>());

            Assert.IsNotNull(retLists);
            Assert.AreEqual(retLists.ResponseObject.Count, numofLists);

        }
        [Category("Watchlist repository test")]
        [Test]
        public void Test_GetWatchlists_ShouldReturnEmptyButValidResults()
        {
            int numofLists = 0;
            var testList = WatchlistTestDataHelper.CreateXWatchlists(numofLists);

            watchlistProviderDependency.Setup(x => x.GetInvestorWatchlists(It.IsAny<int>())).Returns(testList);
            var retLists = reposToTest.GetWatchlists(It.IsAny<int>());

            Assert.IsNotNull(retLists);
            Assert.AreEqual(retLists.ResponseObject.Count, numofLists);

        }
        [Category("Watchlist repository test")]
        [Test]
        public void Test_GetWatchlists_ShouldReturnNullResults()
        {
            var retObject = new Definitions.MethodResultContainer<List<Definitions.Watchlist>>();
            retObject.ResponseObject = null;
            watchlistProviderDependency.Setup(x => x.GetInvestorWatchlists(It.IsAny<int>())).Returns(retObject);
            var retLists = reposToTest.GetWatchlists(It.IsAny<int>());

            Assert.IsNull(retLists.ResponseObject);
        }
    }
}
