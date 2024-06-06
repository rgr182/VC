using VC_API.Domain.Repositories;
using VC_API.Entities;
using VC_API.Entities.DTOs;

namespace VC_API.Domain.Services
{
    public interface IPetsService
    {
        Task<IEnumerable<PetDTO>> GetAllPetsAsync();
        Task<Pets> GetPetByIdAsync(int id);
        Task AddPetAsync(Pets pet);
        Task UpdatePetAsync(Pets pet);
        Task DeletePetAsync(int id);
    }

    public class PetsService : IPetsService
    {
        private readonly IPetsRepository _petRepository;

        public PetsService(IPetsRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public async Task<IEnumerable<PetDTO>> GetAllPetsAsync()
        {
            return await _petRepository.GetAllPetsAsync();
        }

        public async Task<Pets> GetPetByIdAsync(int id)
        {
            return await _petRepository.GetPetByIdAsync(id);
        }

        public async Task AddPetAsync(Pets pet)
        {
            await _petRepository.AddPetAsync(pet);
        }

        public async Task UpdatePetAsync(Pets pet)
        {
            await _petRepository.UpdatePetAsync(pet);
        }

        public async Task DeletePetAsync(int id)
        {
            await _petRepository.DeletePetAsync(id);
        }
    }
}
