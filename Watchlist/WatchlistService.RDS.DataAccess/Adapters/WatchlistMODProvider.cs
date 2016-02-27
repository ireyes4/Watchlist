using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchlistService.Definitions;
using WatchlistService.ExternalServices;

namespace WatchlistService.DataAccess.Adapters
{
    internal class WatchlistMODProvider : WatchlistBaseDataProvider
    {

        public WatchlistMODProvider(IQuoteProvider quoteProvider)
        {
            _quoteProvider = quoteProvider;
        }
        public override MethodResultContainer<int> CreateInvestorWatchlist(int investorID, Watchlist watchlistToCreate)
        {
            throw new NotImplementedException();
        }

        public override MethodResultContainer<bool> DeleteWatchlist(int investorId, int watchlistID)
        {
            throw new NotImplementedException();
        }

        public override MethodResultContainer<List<Watchlist>> GetInvestorWatchlists(int investorID)
        {
            throw new NotImplementedException();
        }

        public override MethodResultContainer<bool> UpdateInvestorWatchlist(Watchlist watchlistToUpdate)
        {
            throw new NotImplementedException();
        }

        public override MethodResultContainer<WatchlistQuotes> GetQuotesForWatchlist(int watchlistId)
        {
            throw new NotImplementedException();
        }
        protected override MethodResultContainer<List<WatchlistDefinition>> GetWatchlistsForInvestor(int investorID)
        {
            throw new NotImplementedException();
        }
    }
}
