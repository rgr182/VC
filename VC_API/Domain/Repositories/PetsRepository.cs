using Microsoft.EntityFrameworkCore;
using VC_API.Domain.Context;
using VC_API.Domain.Entities;

namespace VC_API.Domain.Repositories
{
    public interface IPetsRepository
    {
        Task<List<Pets>> GetAllPetsAsync();
        Task<Pets> GetPetByIdAsync(int id);
        Task AddPetAsync(Pets pet);
        Task UpdatePetAsync(Pets pet);
        Task DeletePetAsync(int id);
    }

    public class PetsRepository : IPetsRepository
    {
        private readonly PetDbContext _dbContext;

        public PetsRepository(PetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Pets>> GetAllPetsAsync()
        {
            return await _dbContext.Pets.ToListAsync();
        }

        public async Task<Pets> GetPetByIdAsync(int id)
        {
            return await _dbContext.Pets.FindAsync(id);
        }

        public async Task AddPetAsync(Pets pet)
        {
            try
            {
                _dbContext.Pets.Add(pet);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }            
        }

        public async Task UpdatePetAsync(Pets pet)
        {
            _dbContext.Entry(pet).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePetAsync(int id)
        {
            var pet = await _dbContext.Pets.FindAsync(id);
            _dbContext.Pets.Remove(pet);
            await _dbContext.SaveChangesAsync();
        }
    }
}
