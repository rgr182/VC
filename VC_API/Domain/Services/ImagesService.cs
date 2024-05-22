using Microsoft.AspNetCore.Identity;
using VC_API.Domain.Repositories;
using VC_API.Entities;
using VC_API.Entities.DTOs;

namespace VC_API.Domain.Services
{
    public interface IImagesService
    {
        Task<Images> GetImage(int id);
    }
    public class ImagesService:IImagesService
    {
        private readonly IImagesRepository  _repository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ImagesService> _logger;
        public ImagesService(IImagesRepository repository,
    IConfiguration configuration, ILogger<ImagesService> logger)
        {
            _repository = repository;
            _configuration = configuration;
            _logger = logger;
        }
        public async Task<Images> GetImage(int id)
        {
            return await _repository.GetImage(id);
        }
    }
}
