using Microsoft.EntityFrameworkCore;

namespace GrupparbeteAuktion.Domain.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Users> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // OnModelCreating används för att definiera relationer mellan entiteter
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>()
                .HasKey(u => u.UserID);

            modelBuilder.Entity<Auction>()
                .HasKey(a => a.AuctionID);

            modelBuilder.Entity<Bid>()
                .HasKey(b => b.BidID);

            // Definiera relationer mellan Bid och Auction
            modelBuilder.Entity<Bid>()
                .HasOne(b => b.Auction)       // En Bid har en Auction
                .WithMany(a => a.Bids)        // En Auction har många Bids
                .HasForeignKey(b => b.AuctionID); // FK i Bid pekar på AuctionID

            // Definiera relationer mellan Bid och User
            modelBuilder.Entity<Bid>()
                .HasOne(b => b.User)          // En Bid har en User
                .WithMany(u => u.Bids)        // En User har många Bids
                .HasForeignKey(b => b.UserID); // FK i Bid pekar på UserID
        }
    }
}
