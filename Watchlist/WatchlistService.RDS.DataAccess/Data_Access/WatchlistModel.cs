namespace WatchlistService.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WatchlistModel : DbContext
    {
        public WatchlistModel()
            : base("name=Watchlist")
        {
        }

        public virtual DbSet<tblWatchlist> Watchlists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblWatchlist>()
                .Property(e => e.WatchlistName)
                .IsUnicode(false);

            modelBuilder.Entity<tblWatchlist>()
                .Property(e => e.QuotesList)
                .IsUnicode(false);
        }
    }
}
