using Microsoft.AspNetCore.Mvc;
using VC_API.Domain.Services;
using VC_API.Entities;
using VC_API.Models;

namespace VC_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ILogger<PetsController> _logger;
        private readonly IPetsService _petService;

        public PetsController(ILogger<PetsController> logger, IPetsService petService)
        {
            _logger = logger;
            _petService = petService;
        }

        // Add a new pet
        [HttpPost(Name = "SavePet")]
        public async Task<IActionResult> SavePet([FromBody] PetVM pet)
        {
            try
            {                
                await _petService.AddPetAsync(pet);
                return Ok(pet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving the pet.");
                return StatusCode(500, "Error saving the pet.");
            }
        }

        // Get a pet by ID
        [HttpGet("{id}", Name = "GetPet")]
        public async Task<IActionResult> GetPet(int id)
        {
            try
            {
                var pet = await _petService.GetPetByIdAsync(id);
                if (pet == null)
                    return NotFound();

                return Ok(pet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting the pet.");
                return StatusCode(500, "Error getting the pet.");
            }
        }

        // Endpoint para obtener todos los perros
        [HttpGet]
        public async Task<IActionResult> GetAllPets()
        {
            try
            {
                var pets = await _petService.GetAllPetsAsync();
                return Ok(pets);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all pets.");
                return StatusCode(500, "Error getting all pets.");
            }
        }

        // Update an existing pet
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePet(int id, Pets pet)
        {
            try
            {
                var existingPet = await _petService.GetPetByIdAsync(id);
                if (existingPet == null)
                    return NotFound();

                var updatedPet = pet;
                updatedPet.PetId = id;

                await _petService.UpdatePetAsync(updatedPet);
                return Ok(updatedPet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating the pet.");
                return StatusCode(500, "Error updating the pet.");
            }
        }

        // Delete an existing pet
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            try
            {
                var existingPet = await _petService.GetPetByIdAsync(id);
                if (existingPet == null)
                    return NotFound();

                await _petService.DeletePetAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting the pet.");
                return StatusCode(500, "Error deleting the pet.");
            }
        }
    }
}
