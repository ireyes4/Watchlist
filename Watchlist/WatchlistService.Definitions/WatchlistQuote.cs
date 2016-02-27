using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchlistService.Definitions
{
    public class WatchlistQuotes : List<WatchlistQuote>
    {

    }
    public class WatchlistQuote
    {
        public decimal Price { get; set; } 
        public decimal Change { get; set; }
        public decimal PercentChange { get; set; }
        public DateTime? AsOfTimestamp { get; set; }
        public decimal LastPrice { get; set; }
        public decimal AskPrice { get; set; }
        public decimal BidPrice { get; set; }
        public decimal AskSize { get; set; }
        public decimal BidSize { get; set; }
        public decimal PreviousClose { get; set; }
        public decimal FiftyTwoWeekHigh { get; set; }
        public decimal FiftyTwoWeekLow { get; set; }
        //public QuoteType QuoteType { get; set; } (this is an enum)
        //public Security Security (this is a class that contains the following)
        //                                        public string Description { get; set; }
        //                                        public string Symbol { get; set; }
        //                                        public string Identifier { get; set; }
        //                                        public Nullable<bool> IsTradable { get; set; }
        //                                        public string InputSymbol { get; set; }
        //                                        public string DisplaySymbol { get; set; }
        //                                        public Nullable<bool> IsAIPTradable { get; set; }
        //public QuoteServiceLevel QuoteServiceLevel { get; set; }
        public bool? IsCaveatEmptor { get; set; }
        public decimal LeveragedFundFlag { get; set; }
        public decimal InverseFundFlag { get; set; }
        public string Exchange { get; set; }
        public string ExchangeCode { get; set; }
        public string Symbol { get; set; }

    }
}
