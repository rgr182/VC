using Microsoft.EntityFrameworkCore;
using VC_API.Domain;
using VC_API.Domain.Context;
using VC_API.Entities;
public interface IUserRepository
{
    Task<User> GetUser(int id);
    Task<User> GetUserByEmail(string email);
    Task<User> AddUser(User user);
}
public class UsersRepository : IUserRepository
{
    private readonly PetDbContext _context;
    private readonly ILogger<UsersRepository> _logger;

    public UsersRepository(PetDbContext context, ILogger<UsersRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<User> GetUser(int id)
    {
        return await _context.Users.FindAsync(id);
    }
    public async Task<User> GetUserByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
    public async Task<User> AddUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }
}

