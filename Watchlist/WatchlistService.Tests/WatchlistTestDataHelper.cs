using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchlistService.Definitions;

namespace WatchlistService.Tests
{
    public static class WatchlistTestDataHelper
    {
        public static MethodResultContainer<List<Watchlist>> CreateXWatchlists(int numOfWatchlists)
        {
            var retObject = new MethodResultContainer<List<Watchlist>>();
            var retListofWatchlists = new List<Watchlist>();
            for (int i = 0; i < numOfWatchlists; i++)
            {
                retListofWatchlists.Add(new Watchlist()
                {
                    ID = i,
                    Name = string.Format("Watchlist {0}", i),
                    SymbolList = new SymbolList()
                    {
                        "MSFT"
                    }
                });
            }
            retObject.ResponseObject = retListofWatchlists;
            return retObject;
        }
    }
}
