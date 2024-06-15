using Azure;
using Microsoft.AspNetCore.Mvc;
using VC_API.Entities;
using System.IO;
using Microsoft.AspNetCore.Http.HttpResults;
using VC_API.Domain.Services;
using VC_API.Entities.DTOs;

namespace VC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ILogger<ImagesController> _logger;
        private readonly IImagesService _Imagesservice;
        public ImagesController(ILogger<ImagesController> logger, IImagesService imagesservice)
        {
            _logger = logger;
            _Imagesservice = imagesservice;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> UploadFile(ImagesDTO images)
        {
            try
            {
                await _Imagesservice.addImage(images);
                return Ok(images);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving the image.");
                return StatusCode(500, "Error saving the image.");
            }
        }
        [HttpPost("Show")]
        public Stream GetFile(int Id)
        {
            Stream stream2 = null;
            try
            {
                string path = Path.Combine("~\\Images\\", Id.ToString()+ ".png");
                stream2 = new FileStream(path, FileMode.Open);
                return stream2;
            }
            catch (Exception ex)
            {
                return stream2;
            }
        }
        [HttpPost("ImageUrl")]
        public async Task<IActionResult> getImageURL(int petId)
        {
            try
            {
                var image = await _Imagesservice.getImageURL(petId);
                if (image == null)
                    return NotFound();

                return Ok(image);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting the image.");
                return StatusCode(500, "Error getting the image.");
            }
        }
    }
}