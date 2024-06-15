using Microsoft.EntityFrameworkCore;
using VC_API.Domain.Context;
using VC_API.Entities;
using VC_API.Entities.DTOs;

namespace VC_API.Domain.Repositories
{
    public interface IPetsRepository
    {
        Task<IEnumerable<PetDTO>> GetAllPetsAsync();
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

        public async Task<IEnumerable<PetDTO>> GetAllPetsAsync()
        {
            var query = from pet in _dbContext.Pets
                        select new 
                        { 
                            petId = pet.PetId,
                            name = pet.Name,
                            description = pet.Description,
                            color = pet.Color,
                            gender = pet.Gender,
                            address = pet.Address,
                            latitude = pet.Latitude,
                            longitude = pet.Longitude,
                            createdDate = pet.CreatedDate,
                            Status = pet.status
                        };
            var result = await query.ToListAsync();
            return result.Select(r => new PetDTO { 
                PetId = r.petId,
                Name = r.name,
                Description = r.description,
                Color = r.color,
                Gender = r.gender,
                Address = r.address,
                Latitude = r.latitude,
                Longitude = r.longitude,
                CreatedDate = r.createdDate,
                status = r.Status
            });
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
