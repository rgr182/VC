using Amazon.S3;
using VC_API.Domain.Repositories;
using VC_API.Entities;
using VC_API.Models;

namespace VC_API.Domain.Services
{
    public interface IPetsService
    {
        Task<List<Pets>> GetAllPetsAsync();
        Task<Pets> GetPetByIdAsync(int id);
        Task AddPetAsync(PetVM pet);
        Task UpdatePetAsync(Pets pet);
        Task DeletePetAsync(int id);
    }

    public class PetsService : IPetsService
    {
        private readonly IPetsRepository _petRepository;
        private readonly IAmazonS3Service _amazonS3Service;

        public PetsService(IPetsRepository petRepository, IAmazonS3Service amazonS3Service)
        {
            _petRepository = petRepository;
            _amazonS3Service = amazonS3Service;
        }

        public async Task<List<Pets>> GetAllPetsAsync()
        {
            return await _petRepository.GetAllPetsAsync();
        }

        public async Task<Pets> GetPetByIdAsync(int id)
        {
            return await _petRepository.GetPetByIdAsync(id);
        }

        public async Task AddPetAsync(PetVM pet)
        {
            // Obtener la URL de la imagen después de cargarla en S3
            string imageUrl = await _amazonS3Service.UploadImageAndGetUrlAsync(pet.Image, "nombre-del-archivo.jpg");

            // Crear un objeto Pets con los datos recibidos y la URL de la imagen
            Pets newPet = new Pets
            {
                Name = pet.Name,
                Description = pet.Description,
                Color = pet.Color,
                Gender = pet.Gender,
                Address = pet.Address,
                Latitude = pet.Latitude,
                Longitude = pet.Longitude,
                ImageUrl = imageUrl // Asignar la URL de la imagen
            };

            // Agregar la nueva mascota al repositorio
            await _petRepository.AddPetAsync(newPet);
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

    public interface IAmazonS3Service
    {
        Task<string> UploadImageAndGetUrlAsync(byte[] imageBytes, string fileName);
    }

    public class AmazonS3Service : IAmazonS3Service
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName;

        public AmazonS3Service(IAmazonS3 s3Client, string bucketName)
        {
            _s3Client = s3Client;
            _bucketName = bucketName;
        }

        public async Task<string> UploadImageAndGetUrlAsync(byte[] imageBytes, string fileName)
        {
            try
            {
                var putObjectRequest = new PutObjectRequest
                {
                    BucketName = _bucketName,
                    Key = $"imagenes/{Guid.NewGuid()}{Path.GetExtension(fileName)}",
                    InputStream = new MemoryStream(imageBytes),
                    ContentType = "image/jpeg"
                };

                var response = await _s3Client.PutObjectAsync(putObjectRequest);

                if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    return $"https://{_bucketName}.s3.amazonaws.com/{putObjectRequest.Key}";
                }
                else
                {
                    return null;
                }
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
                return null;
            }
        }
    }
}
