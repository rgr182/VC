using VC_API.Domain.Context;
using VC_API.Entities;

namespace VC_API.Domain.Repositories
{
    public interface IImagesRepository
    {
        Task<Images> GetImage(int id);
    }
    public class ImagesRepository : IImagesRepository
    {
        private readonly PetDbContext _context;
        private readonly ILogger<ImagesRepository> _logger;

        public ImagesRepository(PetDbContext context, ILogger<ImagesRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Images> GetImage(int id)
        {
            return await _context.Images.FindAsync(id);
        }
    }
}
