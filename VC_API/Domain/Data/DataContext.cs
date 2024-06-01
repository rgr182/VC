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
    }
}
