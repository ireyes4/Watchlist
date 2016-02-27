using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using WatchlistService.DataAccess.Configuration;
using WatchlistService.Definitions;
using WatchlistService.ExternalServices;

namespace WatchlistService.DataAccess
{
    public class WatchlistDataProvider : IWatchlistDataProvider
    {
        private IWatchlistDataProvider _dataProvider = null;
        private IQuoteProvider _quoteProvider = null;

        public WatchlistDataProvider(IQuoteProvider quoteProvider)
        {
            _quoteProvider = quoteProvider;

            //Gather all the data providers from config
            var providerConfigSection = (WatchlistDataProviderSection)ConfigurationManager.GetSection("WatchlistDataProviderSection");

            //throw exception if section is not found in config file
            if (providerConfigSection == null || providerConfigSection.DataProvider == null)
            {
                throw new ConfigurationErrorsException("Could not find <WatchlistDataProviderSection> node in configuration file");
            }

            //load provider type from config and reflect new data provider
            WatchlistService.DataAccess.Configuration.WatchlistDataProvider listedProvider = providerConfigSection.DataProvider;
            _dataProvider = (IWatchlistDataProvider)Activator.CreateInstance(Type.GetType(listedProvider.Type), _quoteProvider);
            
        }
        /// <summary>
        /// Return all watchlists from each data source, based on investor ID
        /// </summary>
        /// <param name="investorID"></param>
        /// <returns></returns>
        MethodResultContainer<List<Definitions.Watchlist>> IWatchlistDataProvider.GetInvestorWatchlists(int investorID)
        {
            return _dataProvider.GetInvestorWatchlists(investorID);
        }
        MethodResultContainer<int> IWatchlistDataProvider.CreateInvestorWatchlist(int investorID, Definitions.Watchlist watchlistToCreate)
        {
            return _dataProvider.CreateInvestorWatchlist(investorID, watchlistToCreate);
        }

        MethodResultContainer<bool> IWatchlistDataProvider.UpdateInvestorWatchlist(Definitions.Watchlist watchlistToUpdate)
        {
            return _dataProvider.UpdateInvestorWatchlist(watchlistToUpdate);
        }

        MethodResultContainer<bool> IWatchlistDataProvider.DeleteWatchlist(int investorId, int watchlistID)
        {
            return _dataProvider.DeleteWatchlist(investorId, watchlistID);
        }
        MethodResultContainer<WatchlistQuotes> IWatchlistDataProvider.GetQuotesForWatchlist(int watchlistId)
        {
            return _dataProvider.GetQuotesForWatchlist(watchlistId);
        }
    }
}
