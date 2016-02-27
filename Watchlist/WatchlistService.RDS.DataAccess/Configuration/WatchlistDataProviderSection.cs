using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace WatchlistService.DataAccess.Configuration
{
    public class WatchlistDataProviderSection : ConfigurationSection
    {
        [ConfigurationProperty("WatchlistDataProvider", IsRequired = true)]
        public WatchlistDataProvider DataProvider
        {
            get
            {
                return base["WatchlistDataProvider"] as WatchlistDataProvider;
            }
        }
    }
    
    public class WatchlistDataProvider : ConfigurationElement
    {

        [ConfigurationProperty("type", IsKey = true, IsRequired = true)]
        public string Type
        {
            get
            {
                return base["type"] as string;
            }
            set
            {
                base["type"] = value;
            }
        }
    }
}
