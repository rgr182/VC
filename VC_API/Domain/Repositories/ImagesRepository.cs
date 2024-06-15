using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VC_API.Domain.Context;
using VC_API.Entities.DTOs;
using VC_API.Entities;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Collections;

namespace VC_API.Domain.Repositories
{
    public interface IImagesRepository
    {
        Task<Images> addImage(ImagesDTO images);
        Task<Images> getImageURL(int petId);
    }
    public class ImagesRepository : IImagesRepository
    {
        private readonly PetDbContext _dbContext;
        private readonly ILogger<ImagesRepository> _logger;
        public ImagesRepository(PetDbContext context, ILogger<ImagesRepository> logger)
        {
            _dbContext = context;
            _logger = logger;
        }
        public async Task<Images> addImage([FromForm] ImagesDTO images)
        {

            var directoryPath = "~\\Images\\";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            var fileName = Path.GetFileName(images.PetId.ToString() + ".png");
            var path = Path.Combine("~\\Images\\", fileName);
            var newImage = new Images
            {
                PetId = images.PetId,
                ImageURL = path
            };
            _dbContext.Images.Add(newImage);
            await _dbContext.SaveChangesAsync();
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                images.File.CopyTo(stream);
            };
            return(newImage);
        }
        public async Task<Images> getImageURL(int petId)
        {
            return await _dbContext.Images.FindAsync(petId);
        }
    }
}
