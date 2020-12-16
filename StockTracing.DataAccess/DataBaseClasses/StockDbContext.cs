using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockTracing.DataAccess.DataBaseClasses
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<category> categories { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<companyUser> companyUsers { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Stock> stocks { get; set; }
        public DbSet<StockFile> stockFiles { get; set; }
        public DbSet<stockProduct> stockProducts { get; set; }
        public DbSet<users> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<companyUser>(o =>
            {
                o.HasKey(r => new { r.userId, r.companyId });
            });

            modelBuilder.Entity<stockProduct>(o =>
            {
                o.Property(r => r.Id).HasColumnName("productId");
                o.HasKey(r => new { r.stockId, r.Id });
            });
            
        }

    }
}
