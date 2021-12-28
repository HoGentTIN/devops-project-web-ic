using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArtSquare.Shared.Models;

namespace ArtSquare.Server.Data
{
    public class ArtSquareServerContext : DbContext
    {
        public ArtSquareServerContext (DbContextOptions<ArtSquareServerContext> options)
            : base(options)
        {
        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<UserArt> UserArts { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Tags>().ToTable("Tags");
            modelBuilder.Entity<Artist>().ToTable("Artists");
            modelBuilder.Entity<ShoppingCart>().ToTable("ShoppingCart");
            modelBuilder.Entity<Auction>().ToTable("Auctions");
        }
    }
}
