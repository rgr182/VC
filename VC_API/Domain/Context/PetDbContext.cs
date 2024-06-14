using Microsoft.EntityFrameworkCore;
using VC_API.Domain.Entities;

namespace VC_API.Domain.Context
{
    public class PetDbContext : DbContext
    {
        public PetDbContext(DbContextOptions<PetDbContext> options) : base(options)
        {
        }

        public DbSet<Pets> Pets { get; set; }
        public DbSet<Toys> Toys { get; set; }
        public DbSet<ClothingAndAccessories> ClothingAndAccessories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MedicinesAndFood> MedicinesAndFood { get; set; }
        public DbSet<ProductCategories> ProductCategory { get; set; }
    }
}
