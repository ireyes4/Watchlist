using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchlistService.Definitions;
using WatchlistService.ExternalServices.QuoteService.Request;

namespace WatchlistService.ExternalServices
{
    public interface IQuoteProvider
    {
        /// <summary>
        /// Obtain Populated Quotes from External Service
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        MethodResultContainer<QuoteList> GetQuotes(QuotesServiceRequest request);
    }
}
