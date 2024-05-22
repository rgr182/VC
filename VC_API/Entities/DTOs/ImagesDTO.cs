namespace VC_API.Entities.DTOs
{
    public class ImagesDTO
    {
        public int PetId { get; set; }
        public required IFormFile File { get; set; }
    }
}
