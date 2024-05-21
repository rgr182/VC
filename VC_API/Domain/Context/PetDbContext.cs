using Microsoft.EntityFrameworkCore;
using VC_API.Entities;

namespace VC_API.Domain.Context
{
    public class PetDbContext : DbContext
    {
        public PetDbContext(DbContextOptions<PetDbContext> options) : base(options)
        {
        }

        public DbSet<Pets> Pets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Images> Images { get; set; }
       
    }
}
