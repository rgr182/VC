using Microsoft.AspNetCore.Mvc;
using VC_API.Domain.Repositories;
using VC_API.Entities;
using VC_API.Entities.DTOs;

namespace VC_API.Domain.Services
{
    public interface IImagesService
    {
        Task<Images> addImage(ImagesDTO images);
        Task<Images> getImageURL(int petId);
    }
    public class ImagesService : IImagesService
    {
        private readonly IImagesRepository _ImagesRepository;
        public ImagesService(IImagesRepository imagesRepository)
        {
            _ImagesRepository = imagesRepository;
        }
        public async Task<Images> addImage(ImagesDTO images)
        {
            return await _ImagesRepository.addImage(images);
        }
        public async Task<Images> getImageURL(int petId)
        {
            return await _ImagesRepository.getImageURL(petId);
        }
    }
}
