using System;
using System.Collections.Generic;

namespace WatchlistService.Definitions
{
    public class QuoteList : List<Quote>
    {

    }
    public class Quote
    {
        public object QuoteStatus { get; set; }
        public decimal Change { get; set; }
        public decimal ChangePercent { get; set; }
        public string Company { get; set; }
        public string Cusip { get; set; }
        public decimal High52Week { get; set; }
        public DateTime? High52WeekDate { get; set; }
        public decimal Last { get; set; }
        public decimal Low52Week { get; set; }
        public DateTime? Low52WeekDate { get; set; }
        public List<string> MatchedTypes { get; set; }
        public decimal PrevClose { get; set; }
        public string QuoteType { get; set; }
        public string Symbol { get; set; }
        public string SymbolType { get; set; }
        public DateTime? TimeStamp { get; set; }
        public decimal TimeZone { get; set; }
        public string WSODIssueSymbol { get; set; }
        public bool IsTradeable { get; set; }
        public bool AllowedInPlan { get; set; }
        public long MarketCap { get; set; }
        public decimal PERatio { get; set; }
        public decimal DivYield { get; set; }
        public decimal LastDivAmt { get; set; }
        public DateTime? LastDivDate { get; set; }
        public decimal Ask { get; set; }
        public decimal AskSize { get; set; }
        public decimal Bid { get; set; }
        public decimal BidSize { get; set; }
        public string Exchange { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Open { get; set; }
        public decimal Volume { get; set; }
        public decimal VolumeAvg10Day { get; set; }
        public decimal VolumeAvg20Day { get; set; }
        public decimal ChangeYTD { get; set; }
        public decimal ChangePercentYTD { get; set; }
        public decimal ExpenseRatio { get; set; }
        public string FundCategory { get; set; }
        public decimal GrossExpenseRatio { get; set; }
        public DateTime? InceptionDate { get; set; }
        public decimal LoadAmount { get; set; }
        public string LoadType { get; set; }
        public decimal NetAssets { get; set; }
        public object StandardizedAsOfDate { get; set; }
        public decimal StandardizedReturnY1 { get; set; }
        public decimal StandardizedReturnY3 { get; set; }
        public decimal StandardizedReturnY5 { get; set; }
        public decimal StandardizedReturnY10 { get; set; }
        public decimal StandardizedReturnSinceInception { get; set; }
        public decimal LeveragedFundFlag { get; set; }
        public decimal InverseFund { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public decimal Opendecimalerest { get; set; }
        public string PutCall { get; set; }
        public decimal StrikePrice { get; set; }
        public decimal UnderlierAsk { get; set; }
        public decimal UnderlierBid { get; set; }
        public decimal UnderlierChange { get; set; }
        public string UnderlierCompany { get; set; }
        public string UnderlierExchange { get; set; }
        public decimal UnderlierHigh { get; set; }
        public decimal UnderlierLast { get; set; }
        public decimal UnderlierLow { get; set; }
        public List<string> UnderlierMatchedTypes { get; set; }
        public string UnderlierSymbol { get; set; }
        public string UnderlierSymbolType { get; set; }
        public decimal UnderlierVolume { get; set; }
        public bool? CaveatEmptor { get; set; }
    }
}
