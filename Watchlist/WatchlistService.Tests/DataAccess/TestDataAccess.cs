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

namespace WatchlistService.Tests.DataAccess
{
    [TestFixture]
    public class TestDataAccess
    {
        private WatchlistService.Controllers.WatchlistController _controller;
        private Mock<IWatchlistRepository> repos;

        [SetUp]
        public void SetUp()
        {
            //TO DO
            // repos = new Mock<IWatchlistRepository>();
            //this._controller = new WatchlistService.Controllers.WatchlistController(repos.Object);
        }

        [Category("Watchlist Data Access Test")]
        [Test]
        public void Test_DataAccess_WatchListMODProvider_()
        {
            //TO DO LIST
        }
    }
}