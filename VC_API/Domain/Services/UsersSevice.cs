using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VC_API.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VC_API.Domain.Services.Interfaces;
using VC_API.Domain.Repositories;
using static System.Net.WebRequestMethods;

public class UsersSevice : IuserService
{
    private readonly IUserRepository _repository;
    private readonly IConfiguration _configuration;
    private readonly ILogger<UserService> _logger;
    private readonly IEmailService _emailService;
    public UserService(IUserRepository repository,
    IConfiguration configuration, ILogger<UsersSevice> logger,
    IEmailService emailService)
    {
        _repository = repository;
        _configuration = configuration;
        _logger = logger;
        _emailService = emailService;
    }
    public async Task<User> GetUser(int id)
    {
        return await _repository.GetUser(id);
    }
    public async Task<User> Register(UserRegistrationDTO registrationDTO)
    {
        try
        {
            // Check if a user with the same email already exists
            var existingUser = await _repository.GetUserByEmail(registrationDTO.Email);
            if (existingUser != null)
            {
                throw new Exception("An account with this email already exists.");
            }
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(registrationDTO.Password);
            string token = Guid.NewGuid().ToString();
            string tokenHash = BCrypt.Net.BCrypt.HashPassword(token);
            User user = new User
            {
                Name = registrationDTO.Name,
                Surname = registrationDTO.Surname,
                Email = registrationDTO.Email,
                PhoneNumber = registrationDTO.PhoneNumber,
                Password = passwordHash,
                AddressLine1 = registrationDTO.AddressLine1,
            };

            return await _repository.AddUser(user);
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException != null && ex.InnerException is SqlException sqlEx && (sqlEx.Number == 2601 || sqlEx.Number == 2627))
            {
                throw new Exception("An account with this email already exists.");
            }
            throw;
        }
    }
    public async Task<string> Login(string email, string password)
    {
        var user = await _repository.GetUserByEmail(email);

        if (user == null)
        {
            return null;
        }
        var tokenHandler = new JwtSecurityTokenHandler();
        //TODO - Use Azure keystore for production
        var key = Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, user.Id.ToString())}),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    public async Task<User> GetUserByEmail(string email)
    {
        return await _repository.GetUserByEmail(email);
    }
}

