using Microsoft.EntityFrameworkCore;
using VC_API.Domain.Context;
using VC_API.Domain.Entities;

namespace VC_API.Domain.Repositories
{
    public class ProductRepository
    {
        private readonly PetDbContext _dbContext;

        public async Task<List<Product>> GetAllProductAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }
    }

}

