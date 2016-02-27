using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchlistService.ExternalServices.QuoteService.Request
{
    public class QuotesServiceRequest
    {
        public string UserID { get; set; }
        public string UserTier { get; set; }
        public string SourceSystemID { get; set; }
        public string ReferralSourceID { get; set; }
        public string RequestID { get; set; }
        public string SessionID { get; set; }
        public List<string> Symbols { get; set; }
    }
}
