using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using Newtonsoft.Json;
using WatchlistService.Services;
using Moq;
using WatchlistService.Models;
using WatchlistService.Definitions;
using NUnit.Framework;
using System.Web.Http.Results;

namespace WatchlistService.Tests.Controllers
{
    [TestFixture]
    public class TestWatchlistController
    {
        private WatchlistService.Controllers.WatchlistController _controller;
        private Mock<IWatchlistRepository> repos;

        [SetUp]
        public void SetUp()
        {
            repos = new Mock<IWatchlistRepository>();
            this._controller = new WatchlistService.Controllers.WatchlistController(repos.Object);
        }

        [Category("Watchlist Controller Test")]
        [Test]
        public void Test_GetWatchlistById_ShouldReturnBadRequestWithInvalidInput()
        {
            //var result = _controller.GetWatchlist(-1) as BadRequestResult;

            //Assert.IsNotNull(result);

        }
        [Category("Watchlist Controller Test")]
        [Test]
        public void Test_CreateWatchlist_ShouldReturnGoodRequestWithValidInput()
        {
            //Arrange
            var retObject = new MethodResultContainer<int>();
            repos.Setup(r => r.CreateWatchlist(It.IsAny<WatchlistService.Models.WatchlistModel>())).Returns(retObject);
            
            //Act
            var result = _controller.CreateWatchlist(It.IsAny<WatchlistService.Models.WatchlistModel>()) as OkNegotiatedContentResult<MethodResultContainer<int>>;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.ResponseObject > -1);

        }
        [Category("Watchlist Controller Test")]
        [Test]
        public void Test_GetWatchlistById_ShouldReturnResultWithValidInput()
        {
            var retObject = new MethodResultContainer<List<Definitions.Watchlist>>();
            List<WatchlistService.Definitions.Watchlist> l = new List<Definitions.Watchlist>()
            {
                new Definitions.Watchlist()
                {
                    ID = 1,
                    SymbolList = new SymbolList(),
                    Name = "Foo"
                }
            };
            retObject.ResponseObject = l;
            repos.Setup(r => r.GetWatchlists(1)).Returns(retObject);
            var result = _controller.GetWatchlists(1) as OkNegotiatedContentResult<MethodResultContainer<List<WatchlistService.Definitions.Watchlist>>>;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.ResponseObject.First().ID > 0);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.Content.ResponseObject.First().Name));
        }

        [Category("Watchlist Controller Test")]
        [Test]
        public void Test_GetWatchlistById_ShouldReturnBadRequestWithInvalidInvestorID()
        {
            var result = _controller.GetWatchlists(-1) as NegotiatedContentResult<ApiResponse<WatchlistQuotes>>;

            Assert.IsNotNull(result);
        }
    }
}
