using Microsoft.EntityFrameworkCore;
using PetStoreBackend.Models;

namespace PetStoreBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ClothingAndAccessories> ClothingAndAccessories { get; set; }
        public DbSet<Toy> Toys { get; set; }
        public DbSet<MedicinesAndFood> MedicinesAndFood { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(p => p.ClothingAndAccessories)
                .WithOne(ca => ca.Product)
                .HasForeignKey(ca => ca.ProductID);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Toys)
                .WithOne(t => t.Product)
                .HasForeignKey(t => t.ProductID);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.MedicinesAndFood)
                .WithOne(mf => mf.Product)
                .HasForeignKey(mf => mf.ProductID);
        }
    }
}
