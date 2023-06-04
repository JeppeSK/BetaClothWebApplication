using ClothWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;

namespace ClothWebApplication.Controllers
{
    [Route("api/[controller]/[action]/{id}")]
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
            try
            {
                return Ok(await _context.Clothes.ToListAsync());
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return BadRequest("Invalid request.");
                }
                else if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return NotFound("Resource not found.");
                }
                else
                {
                    return StatusCode(500, "An error occurred while fetching the products.");
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> getProductById(int id)
        {

            try
            {
                var cloth = await _context.Clothes.FirstOrDefaultAsync(x => x.Id == id);

                if (cloth == null)
                {
                    return NotFound("The Cloth you are searching for with that id was not found.");
                }

                return Ok(cloth);
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return BadRequest("Invalid request.");
                }
                else if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return NotFound("Resource not found.");
                }
                else
                {
                    return StatusCode(500, "An error occurred while fetching the product");
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> createProduct([FromBody] Cloth cloth)
        {

            try
            {

                // Add the cloth object to the context
                _context.Clothes.Add(cloth);

                // Save changes to the database
                await _context.SaveChangesAsync();

                // Return a success response
                return Ok("Product created successfully.");

            }
            catch (HttpRequestException ex) 
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return BadRequest("Invalid request.");
                }
                else if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return NotFound("Resource not found.");
                }
                else
                {
                    return StatusCode(500, "An error occurred while creating the product.");
                }
            }
        }
    }
}
