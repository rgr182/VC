using System.ComponentModel.DataAnnotations.Schema;

namespace VC_API.Entities.DTOs
{
    public class ImagesDTO
    {
        public int PetId { get; set; }
        [NotMapped]
        public required IFormFile File { get; set; }
    }
}
