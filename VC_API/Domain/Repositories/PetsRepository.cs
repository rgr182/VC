using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VC_API.Domain.Context;
using VC_API.Entities;
using VC_API.Entities.DTOs;
using static System.Net.Mime.MediaTypeNames;

namespace VC_API.Domain.Repositories
{
    public interface IPetsRepository
    {
        Task<List<Pets>> GetAllPetsAsync();
        Task<Pets> GetPetByIdAsync(int id);
        Task AddPetAsync(PetDTO pet);
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

        public async Task AddPetAsync(PetDTO pet)
        {
            try
            {
                var directoryPath = "~\\Images\\";
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                var fileName = Path.GetFileName(pet.Latitude.ToString()+pet.Longitude + ".png");
                var path = Path.Combine("~\\Images\\", fileName);
                var newPet = new Pets
                {
                    Name = pet.Name,
                    Description = pet.Description,
                    Color = pet.Color,
                    Gender = pet.Gender,
                    Address = pet.Address,
                    Latitude = pet.Latitude,
                    Longitude = pet.Longitude,
                    CreatedDate = DateTime.Now,
                    status = pet.status,
                    ImageURL = path
                };
                _dbContext.Pets.Add(newPet);
                await _dbContext.SaveChangesAsync();
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    pet.File.CopyTo(stream);
                };
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
