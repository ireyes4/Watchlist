using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WatchlistService.Definitions
{
    public class Watchlist
    {
        public int ID { get; set; }

        public SymbolList SymbolList { get; set; }

        public string Name { get; set; }
        
        public Watchlist()
        {
            this.SymbolList = new  SymbolList();
        }
    }
}