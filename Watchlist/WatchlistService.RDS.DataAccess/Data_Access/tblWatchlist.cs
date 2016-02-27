namespace WatchlistService.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblWatchlist")]
    public partial class tblWatchlist
    {
        [Key]
        public int WatchlistID { get; set; }

        [StringLength(100)]
        public string WatchlistName { get; set; }

        [StringLength(1000)]
        public string QuotesList { get; set; }

        public int InvestorID { get; set; }
    }
}
