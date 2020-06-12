using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore;
 

namespace DataLayer.EfCode
{
    public class EfCoreContext : DbContext
    {
        public EfCoreContext(DbContextOptions<EfCoreContext> opts)
            : base(opts) { }



        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Rating> Ratings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Supplier>().ToTable("Supplier");
            modelBuilder.Entity<Rating>().ToTable("Rating");
        }

    }
}
