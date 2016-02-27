using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchlistService.Definitions
{
    public static class ExtensionMethods
    {
        public static WatchlistQuote ToWatchlistQuote(this Quote quoteServiceQuote)
        {
            return quoteServiceQuote == null ? null : 
            
                new WatchlistQuote()
            {
                Price = quoteServiceQuote.Last,
                Change = quoteServiceQuote.Change,
                PercentChange = quoteServiceQuote.ChangePercent,
                AsOfTimestamp = quoteServiceQuote.TimeStamp,
                LastPrice = quoteServiceQuote.Last,
                AskPrice = quoteServiceQuote.Ask,
                BidPrice = quoteServiceQuote.Bid,
                AskSize = quoteServiceQuote.AskSize,
                BidSize = quoteServiceQuote.BidSize,
                PreviousClose = quoteServiceQuote.PrevClose,
                FiftyTwoWeekHigh = quoteServiceQuote.High52Week,
                FiftyTwoWeekLow = quoteServiceQuote.Low52Week,
                IsCaveatEmptor = quoteServiceQuote.CaveatEmptor,
                LeveragedFundFlag = quoteServiceQuote.LeveragedFundFlag,
                InverseFundFlag = quoteServiceQuote.InverseFund,
                Exchange = quoteServiceQuote.Exchange,
                Symbol = quoteServiceQuote.Symbol
            };
        }
    }
}
