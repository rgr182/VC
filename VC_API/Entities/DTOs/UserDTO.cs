namespace VC_API.Entities.DTOs
{
    public class UserRegistrationDTO
    {
        public  string Name { get; set; } = string.Empty;
        public  string Surname { get; set; } = string.Empty;
        public  string Email { get; set; } = string.Empty;
        public  string PhoneNumber { get; set; } = string.Empty;
        public  string Password { get; set; } = string.Empty;
        public string AddressLine1 { get; set; } = string.Empty;
    }
    public class EmailLoginDTO
    {
        public  string Email { get; set; }
        public  string Password { get; set; }
    }
}
