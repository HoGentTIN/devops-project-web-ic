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
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
        }
    }
}
