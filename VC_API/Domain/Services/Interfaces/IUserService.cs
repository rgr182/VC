using VC_API.Entities.DTOs;
using VC_API.Entities;

namespace VC_API.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUser(int id);
        Task<User> GetUserByEmail(string email);
        Task<User> Register(UserRegistrationDTO request);
        Task<string> Login(string email, string password);
    }
}
