using ClothWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;

namespace ClothWebApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClothController : ControllerBase
    {
        private readonly InventoryContext _context;

        public ClothController(InventoryContext context)
        {
            _context = context;
            
        }

        [HttpGet]
        public async Task<IActionResult> getProducts()
        {
            return Ok(await _context.Clothes.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> createProduct([FromBody] Cloth cloth)
        {
            // Add the cloth object to the context
            _context.Clothes.Add(cloth);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return a success response
            return Ok("Product created successfully.");
        }
    }
}
