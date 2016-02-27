using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchlistService.Definitions;

namespace WatchlistService.DataAccess
{
    public interface IWatchlistDataProvider
    {
        MethodResultContainer<List<Watchlist>> GetInvestorWatchlists(int investorID);

        MethodResultContainer<int> CreateInvestorWatchlist(int investorID, Watchlist watchlistToCreate);

        MethodResultContainer<bool> UpdateInvestorWatchlist(Watchlist watchlistToUpdate);

        MethodResultContainer<bool> DeleteWatchlist(int investorId, int watchlistID);

        MethodResultContainer<WatchlistQuotes> GetQuotesForWatchlist(int watchlistId);
    }
}
