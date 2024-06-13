using Azure;
using Microsoft.AspNetCore.Mvc;
using VC_API.Entities;
using System.IO;
using Microsoft.AspNetCore.Http.HttpResults;
using VC_API.Domain.Services;

namespace VC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {


        [HttpPost("Upload")]
        public Task<IActionResult> UploadFile([FromForm] Images images)
        {
            try
            {
                var directoryPath = "~\\Images\\";
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                var fileName = Path.GetFileName(images.PetId.ToString() + ".png");
                var path = Path.Combine("~\\Images\\", fileName);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    images.File.CopyTo(stream);
                }

                return Task.FromResult<IActionResult>(Ok(new { message = "Image added successfully"}));
            }
            catch (Exception ex)
            {
                return Task.FromResult<IActionResult>(BadRequest(ex.Message));
            }
        }
        [HttpPost("Show")]
        public Stream GetFile(int Id)
        {
            Stream stream2 = null;
            try
            {
                
                string path = Path.Combine(@"~\Images", Id.ToString()+ ".png");
                stream2 = new FileStream(path, FileMode.Open);
                return stream2;
                    

            }
            catch (Exception ex)
            {
                return stream2;
            }
        }
    }
}

