namespace VC_API.Entities.DTOs
{
    public class UserRegistrationDTO
    {
        public required string Name { get; set; } = string.Empty;
        public required string Surname { get; set; } = string.Empty;
        public required string Email { get; set; } = string.Empty;
        public required string PhoneNumber { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;
        public string AddressLine1 { get; set; } = string.Empty;
    }
}
