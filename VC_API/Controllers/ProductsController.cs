using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetStoreBackend.Data;
using PetStoreBackend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VC_API.Domain.Data;

namespace PetStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _context.Products
                .Include(p => p.ClothingAndAccessories)
                .Include(p => p.Toys)
                .Include(p => p.MedicinesAndFood)
                .ToListAsync();

            return Ok(products);
        }
    }
}
