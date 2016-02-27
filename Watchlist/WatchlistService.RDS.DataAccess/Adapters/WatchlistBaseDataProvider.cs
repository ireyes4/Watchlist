using Ninject;
using System;
using System.Collections.Generic;
using WatchlistService.Definitions;
using WatchlistService.ExternalServices;

namespace WatchlistService.DataAccess
{
    internal abstract class WatchlistBaseDataProvider : IWatchlistDataProvider
    {
        [Inject]
        protected IQuoteProvider _quoteProvider { get; set; }
        public abstract MethodResultContainer<int> CreateInvestorWatchlist(int investorID, Watchlist watchlistToCreate);
        public abstract MethodResultContainer<bool> DeleteWatchlist(int investorId, int watchlistID);
        public abstract MethodResultContainer<List<Watchlist>> GetInvestorWatchlists(int investorID);
        public abstract MethodResultContainer<bool> UpdateInvestorWatchlist(Watchlist watchlistToUpdate);
        public abstract MethodResultContainer<WatchlistQuotes> GetQuotesForWatchlist(int watchlistId);
        protected abstract MethodResultContainer<List<WatchlistDefinition>> GetWatchlistsForInvestor(int investorID);
    }
}
