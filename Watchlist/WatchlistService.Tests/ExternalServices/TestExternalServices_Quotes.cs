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
using WatchlistService.ExternalServices;
using NUnit.Framework;
using System.Web.Http.Results;
using WatchlistService.ExternalServices.QuoteService.Request;

namespace WatchlistService.Tests.ExternalServices
{
    [TestFixture]
    public class TestExternalServices_Quotes
    {
        private WatchlistService.ExternalServices.QuoteService.Request.QuotesServiceRequest _quoteSvcRequest;
        private Mock<IHttpClientWrapper> repos;
        private IQuoteProvider quoteProvider;

        [SetUp]
        public void SetUp()
        {
           repos = new Mock<IHttpClientWrapper>();
        }

        [Category("Watchlist External Services (Quote) Test")]
        [Test]
        public void Test_ExternalServices_GetQuoteReturnsValues()
        {
            //Arrange
            QuoteList expectedOutput = new QuoteList();
            repos.Setup(x => x.Post<QuotesServiceRequest, QuoteList>(It.IsAny<string>(), It.IsAny<QuotesServiceRequest>())).Returns(expectedOutput);
            quoteProvider = new QuoteProvider(repos.Object);


            //Act
            var quoteList = quoteProvider.GetQuotes(new WatchlistService.ExternalServices.QuoteService.Request.QuotesServiceRequest());
            var actualOutPut = quoteList.ResponseObject as QuoteList ;

            
            //Assert
            Assert.IsNotNull(actualOutPut, "Null is returned from teh actual call.");
            Assert.AreEqual(expectedOutput, actualOutPut, "QuoteProvider.GetQuotes didn't properly set ResponseObject Property");
        }

        [Category("Watchlist External Services (Quote) Test")]
        [Test]
        public void Test_ExternalServices_GetQuoteSetsErrorMessagesWhenExceptionThrown()
        {
            //Arrange
            var expectedMessage = "The service is unavialable";
            var expectedOutput = new Exception(string.Empty,new Exception(expectedMessage));
            repos.Setup(x => x.Post<QuotesServiceRequest, QuoteList>(It.IsAny<string>(), It.IsAny<QuotesServiceRequest>())).Throws(expectedOutput);
            quoteProvider = new QuoteProvider(repos.Object);

   
            //Act
            var quoteList = quoteProvider.GetQuotes(new WatchlistService.ExternalServices.QuoteService.Request.QuotesServiceRequest());
          

            //Assert          
            Assert.AreEqual(MethodResponseCode.ExternalServiceError, quoteList.ResponseCode);
            Assert.AreEqual(expectedMessage, quoteList.ErrorMessage);

        }
    }
}
