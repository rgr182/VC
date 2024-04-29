using Microsoft.AspNetCore.Mvc;
using VC_API.Domain.Entities;
using VC_API.Domain.Services;
using System;
using System.Threading.Tasks;

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

        /// <summary>
        /// Agrega una nueva mascota.
        /// </summary>
        [HttpPost(Name = "SavePet")]
        public async Task<IActionResult> SavePet([FromBody] Pets pet)
        {
            try
            {
                await _petService.AddPetAsync(pet);
                return Ok(pet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar la mascota.");
                return StatusCode(500, "Error al guardar la mascota.");
            }
        }

        /// <summary>
        /// Obtiene una mascota por su ID.
        /// </summary>
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
                _logger.LogError(ex, "Error al obtener la mascota.");
                return StatusCode(500, "Error al obtener la mascota.");
            }
        }

        /// <summary>
        /// Obtiene todas las mascotas.
        /// </summary>
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
                _logger.LogError(ex, "Error al obtener todas las mascotas.");
                return StatusCode(500, "Error al obtener todas las mascotas.");
            }
        }

        /// <summary>
        /// Actualiza una mascota existente.
        /// </summary>
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
                _logger.LogError(ex, "Error al actualizar la mascota.");
                return StatusCode(500, "Error al actualizar la mascota.");
            }
        }

        /// <summary>
        /// Elimina una mascota existente.
        /// </summary>
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
                _logger.LogError(ex, "Error al eliminar la mascota.");
                return StatusCode(500, "Error al eliminar la mascota.");
            }
        }
    }
}
