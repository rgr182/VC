using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VC_API.Entities
{
    public class Pets
    {

        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PetId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public char? Gender { get; set; }
        public string? Address { get; set; }
        public string? ImageURL { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
