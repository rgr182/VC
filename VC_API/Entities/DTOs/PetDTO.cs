using System.ComponentModel.DataAnnotations.Schema;

namespace VC_API.Entities.DTOs
{
    public class PetDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public char? Gender { get; set; }
        public string? Address { get; set; }
        [NotMapped]
        public required IFormFile File { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool status { get; set; }

    }
}
