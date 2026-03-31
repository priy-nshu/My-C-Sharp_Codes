using IdentityAutheticationWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityAutheticationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PlantController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PlantController> _logger;

        public PlantController(ApplicationDbContext context, ILogger<PlantController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllPlants()
        {
            List<Plant> plants = null;
            //string str1 = null;
            //int x = str1.Length;
            plants=await _context.Plants.ToListAsync();

            _logger.LogWarning("Fetched {Count} plants from database",plants.Count    );

            return Ok(plants);
        }

        [Authorize(Roles ="Finance,Admin")]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPlantById(int Id)
        {
            Plant plant;
            try
            {
                plant = await _context.Plants.SingleOrDefaultAsync(p => p.PlantId == Id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in GetPlantId: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return Ok(plant);
        }

        [HttpPost]
        public async Task<IActionResult> PostPlant(Plant plant) {
            if (plant == null) return BadRequest("Plant Data is Required");

            await _context.Plants.AddAsync(plant);
            await _context.SaveChangesAsync();

            return Ok(new { Status = "Success"});
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePlant(int id, Plant previousPlant)
        {
            var plant = await _context.Plants.FindAsync(id);
            if (plant == null)
            {
                return NotFound("Plant not found");
            }
            if (!string.IsNullOrWhiteSpace(previousPlant.Name))
                plant.Name = previousPlant.Name;

            if (!string.IsNullOrWhiteSpace(previousPlant.Description))
                plant.Description = previousPlant.Description;

            if (!string.IsNullOrWhiteSpace(previousPlant.ScientificName))
                plant.ScientificName = previousPlant.ScientificName;

            if (previousPlant.price > 0)
                plant.price = previousPlant.price;

            await _context.SaveChangesAsync();
            return Ok(plant);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlant(int id)
        {
            var plant = await _context.Plants.FindAsync(id);
            if (plant == null)
            {
                return NotFound("Plant not found");
            }

            _context.Plants.Remove(plant);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
