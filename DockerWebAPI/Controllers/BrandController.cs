using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DockerWebAPI.Services;

namespace DockerWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        public readonly IBrandService brandService;
        public BrandController(IBrandService brandService) {
            this.brandService=brandService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllBrands()
        {
            var brands =await brandService.GetAllBrands();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBrandById(int id)
        {
            var result = await brandService.GetBrandById(id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpGet("{name}")]
        public async Task<ActionResult> GetBrandByName(string name)
        {
            var result = await brandService.GetBrandByName(name);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddBrand(Models.Brand brd)
        {
            int result =await brandService.AddBrand(brd);
            if (result == 0) 
                return BadRequest();
            return Ok(result);
        }
    }
}
