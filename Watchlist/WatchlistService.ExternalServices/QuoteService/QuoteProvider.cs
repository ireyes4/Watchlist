using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchlistService.Definitions;
using System.Configuration;
using WatchlistService.ExternalServices.QuoteService.Request;

namespace WatchlistService.ExternalServices
{
    public class QuoteProvider : IQuoteProvider
    {
        private IHttpClientWrapper _client = null;

        /// <summary>
        /// Base URL for Quotes Service that is stored in config
        /// </summary>
        private string quoteServiceBaseAddress = ConfigurationManager.AppSettings["QuoteServiceBaseAddress"];

        /// <summary>
        /// DI-friendly constructor for HttpClientWrapper dependency
        /// </summary>
        /// <param name="client"></param>
        public QuoteProvider(IHttpClientWrapper client)
        {
            _client = client;
        }

        /// <summary>
        /// Obtain Populated Quotes from External Service
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        MethodResultContainer<QuoteList> IQuoteProvider.GetQuotes(QuotesServiceRequest request)
        {
            var retObject = new MethodResultContainer<QuoteList>();
            string fullURI = string.Format("{0}/api/v1/Quotes/Quote", quoteServiceBaseAddress);

            try
            {
                retObject.ResponseObject = _client.Post<QuotesServiceRequest, QuoteList>(fullURI, request);
            }
            catch (Exception GetQuotesException)
            {
                retObject.ResponseCode = MethodResponseCode.ExternalServiceError;
                retObject.ErrorMessage = GetQuotesException.InnerException.Message;
            }
            return retObject;
        }
    }
}
