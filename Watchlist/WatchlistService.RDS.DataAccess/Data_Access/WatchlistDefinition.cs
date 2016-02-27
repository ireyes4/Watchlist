using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchlistService.Definitions;

namespace WatchlistService.DataAccess
{
    public class WatchlistDefinition
    {
        public int ID { get; set; }

        public SymbolList QuoteSymbolList { get; set; }

        public string Name { get; set; }
    }
}
