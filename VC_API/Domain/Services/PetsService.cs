using VC_API.Domain.Entities;
using VC_API.Domain.Repositories;

namespace VC_API.Domain.Services
{
    public interface IPetsService
    {
        Task<List<Pets>> GetAllPetsAsync();
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

        public async Task<List<Pets>> GetAllPetsAsync()
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
