namespace VC_API.Models
{
    public class PetVM
    {       
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public char? Gender { get; set; }
        public string? Address { get; set; }
        public byte[] Image { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
