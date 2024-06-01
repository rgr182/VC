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
    }
}
