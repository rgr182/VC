using Microsoft.AspNetCore.Mvc;
using PetStoreBackend.Models;
using VC_API.Domain.Context;

namespace PetStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly PetDbContext _context;

        public ProductsController(PetDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return Ok();
        }
    }
}
