using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchlistService.DataAccess;
using WatchlistService.Definitions;
using WatchlistService.ExternalServices;
using WatchlistService.ExternalServices.QuoteService.Request;

namespace WatchlistService.DataAccess
{
    internal class WatchlistRDSProvider : WatchlistBaseDataProvider
    {

        public WatchlistRDSProvider()
        {

        }
        public WatchlistRDSProvider(IQuoteProvider quoteProvider)
        {
            _quoteProvider = quoteProvider;
        }

        /// <summary>
        /// Obtain fully populated watchlist data for given investor
        /// </summary>
        /// <param name="investorID"></param>
        /// <returns></returns>
        public override MethodResultContainer<List<Definitions.Watchlist>> GetInvestorWatchlists(int investorID)
        {
            
            List<Definitions.Watchlist> retLists = new List<Watchlist>();
            var retObject = new MethodResultContainer<List<Definitions.Watchlist>>();

            try
            {
                var listsFromDatabase = GetWatchlistsForInvestor(investorID).ResponseObject;

                if (listsFromDatabase != null)
                { 
                    if (listsFromDatabase.Any())
                    {
                        retLists.AddRange(listsFromDatabase.Select(l => new Watchlist() { ID = l.ID, Name = l.Name, SymbolList = l.QuoteSymbolList }));
                    }
                }
                retObject.ResponseObject = retLists;
                    
            }
            catch (Exception getWatchlistException)
            {
                retObject.ErrorMessage = getWatchlistException.Message;
                retObject.ResponseCode = MethodResponseCode.DatabaseError;
            }

            return retObject;    

        }
        public override MethodResultContainer<int> CreateInvestorWatchlist(int investorID, Watchlist watchlistToCreate)
        {
            var retObject = new MethodResultContainer<int>();
            int watchlistID = -1;

            try
            {
                using (WatchlistModel cntx = new WatchlistModel())
                {
                    var watchlist = new tblWatchlist
                    {

                        InvestorID = investorID,
                        WatchlistName = watchlistToCreate.Name,
                        QuotesList = JsonConvert.SerializeObject(watchlistToCreate.SymbolList)
                    };

                    cntx.Watchlists.Add(watchlist);
                    watchlistID = cntx.SaveChanges();
                    retObject.ResponseObject = watchlist.WatchlistID;
                }
                
            }
            catch (Exception CreateWatchlistException)
            {
                retObject.ErrorMessage = CreateWatchlistException.Message;
                retObject.ResponseCode = MethodResponseCode.DatabaseError;
            }
            return retObject;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="watchlistID"></param>
        /// <returns></returns>
        public override MethodResultContainer<bool> DeleteWatchlist(int investorID, int watchlistID)
        {
            var retObject = new MethodResultContainer<bool>();
            
            try {
                using (var ctx = new WatchlistModel())
                {
                    var watchlistToDelete = ctx.Watchlists.Where(w => w.InvestorID == investorID && w.WatchlistID == watchlistID).FirstOrDefault();
                    
                    if (watchlistToDelete == null)
                    {
                        retObject.ResponseCode = MethodResponseCode.DatabaseError;
                        retObject.ErrorMessage = "Invalid Investor ID and Watchlist ID Combination";
                        return retObject;
                    }

                    // Mark entity as deleted
                    ctx.Entry(watchlistToDelete).State = System.Data.Entity.EntityState.Deleted;
                    
                    //Call SaveChanges
                    ctx.SaveChanges();
                    retObject.ResponseObject = true;
                }
                
            }
            catch (Exception DeleteWatchlistException)
            {
                retObject.ErrorMessage = DeleteWatchlistException.Message;
                retObject.ResponseCode = MethodResponseCode.DatabaseError;
                retObject.ResponseObject = false;
            }
            return retObject;
        }
        public override MethodResultContainer<bool> UpdateInvestorWatchlist(Watchlist watchlistToUpdate)
        {
            var retObject = new MethodResultContainer<bool>();

            try {
                using (var ctx = new WatchlistModel())
                {
                    var watchlistToUpdateFromDb = ctx.Watchlists.Where(w => w.WatchlistID == watchlistToUpdate.ID).FirstOrDefault();
                   
                    //Update metadata of watchlist entity coming  from db
                    watchlistToUpdateFromDb.QuotesList = JsonConvert.SerializeObject(watchlistToUpdate.SymbolList);
                    watchlistToUpdateFromDb.WatchlistName = watchlistToUpdate.Name;

                    //Mark entity as modified
                    ctx.Entry(watchlistToUpdateFromDb).State = System.Data.Entity.EntityState.Modified;

                    //Call SaveChanges
                    ctx.SaveChanges();
                    retObject.ResponseObject = true;
                }
                
            }
            catch (Exception UpdateWatchlistException)
            {
                retObject.ErrorMessage = UpdateWatchlistException.Message;
                retObject.ResponseCode = MethodResponseCode.DatabaseError;
                retObject.ResponseObject = false;
            }
            return retObject;
        }
        /// <summary>
        /// Obtain watchlist with populated quote data from quote provider
        /// </summary>
        /// <param name="investorID">Investor ID to pass to quote service</param>
        /// <param name="watchlistDef">WatchlistDefinition containing list of symbols in watchlist</param>
        /// <returns></returns>
        public override MethodResultContainer<WatchlistQuotes> GetQuotesForWatchlist(int watchlistId)
        {
            var retObject = new MethodResultContainer<WatchlistQuotes>();
            tblWatchlist watchlistToRetrieveQuotesFor = null;
            using (var ctx = new WatchlistModel())
            {
                watchlistToRetrieveQuotesFor = ctx.Watchlists.Where(w => w.WatchlistID == watchlistId).FirstOrDefault();
            }
            if (watchlistToRetrieveQuotesFor == null)
            {
                retObject.ErrorMessage = "No Results Retrieved for Watchlist ID";
                retObject.ResponseCode = MethodResponseCode.DatabaseError;
                return retObject;
            }

            QuoteList retList = new QuoteList();
            var quoteRequest = new QuotesServiceRequest()
            {
                UserID = watchlistToRetrieveQuotesFor.InvestorID.ToString(),
                UserTier = "basic",
                SourceSystemID = "SSID1",
                ReferralSourceID = "RSID1",
                RequestID = "RID1",
                SessionID = "SID1",
                Symbols = JsonConvert.DeserializeObject<SymbolList>(watchlistToRetrieveQuotesFor.QuotesList)
            };

            try
            { 
                var quoteList = _quoteProvider.GetQuotes(quoteRequest);

                if (quoteList.ResponseCode != MethodResponseCode.Success)
                {
                    retObject.ResponseCode = quoteList.ResponseCode;
                    retObject.ErrorMessage = quoteList.ErrorMessage;

                    return retObject;
                }

                var wQuoteList = new WatchlistQuotes();
                wQuoteList.AddRange(quoteList.ResponseObject.Select(q => q.ToWatchlistQuote()));
                retObject.ResponseObject = wQuoteList;
            }
            catch (Exception GetQuotesException)
            {
                retObject.ResponseCode = MethodResponseCode.ExternalServiceError;
                retObject.ErrorMessage = GetQuotesException.Message;
            }


            return retObject;
        }
        /// <summary>
        /// Retrieve watchlist definitions from data store
        /// </summary>
        /// <param name="investorID">Investor ID to relate to watchlists in data store</param>
        /// <returns></returns>
        protected override MethodResultContainer<List<WatchlistDefinition>> GetWatchlistsForInvestor(int investorID)
        {
            var retObject = new MethodResultContainer<List<WatchlistDefinition>>();
            List<WatchlistDefinition> result = null;

            try
            {
                using (WatchlistModel db = new WatchlistModel())
                {
                    result = db.Watchlists.Where(w => w.InvestorID == investorID).ToList().Select(x => new WatchlistDefinition
                    {
                        ID = x.WatchlistID,
                        Name = x.WatchlistName,
                        QuoteSymbolList = JsonConvert.DeserializeObject<SymbolList>(x.QuotesList)

                    }).ToList();
                    retObject.ResponseObject = result;
                }
            }
            catch (Exception GetWatchlistException)
            {
                retObject.ResponseCode = MethodResponseCode.DatabaseError;
                retObject.ErrorMessage = GetWatchlistException.Message;
            }
            return retObject;
        }
          
    }
}
