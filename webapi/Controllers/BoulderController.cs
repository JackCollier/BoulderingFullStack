using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Services.BoulderService;

namespace webapi.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class BoulderController : ControllerBase
    {
        private readonly IBoulderService _boulderService;

        public BoulderController(IBoulderService boulderService)
        {
            _boulderService = boulderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Boulder>>> GetBoulders()
        {
            var result = await _boulderService.GetBoulders();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Boulder>> GetBoulderById(int id)
        {
            var result = await _boulderService.GetBoulderById(id);
            if(result is null)
            {
                return NotFound("Not Found");
            }
            return Ok(result);
        }

       [HttpPost]
       public async Task<ActionResult<Boulder>> AddBoulder(Boulder boulder)
        {
            var result = await _boulderService.AddBoulder(boulder);
            return Ok(result);
        }

       [HttpPut]
       public async Task<ActionResult<Boulder>?> UpdateBoulder(Boulder request)
        {
            var result = await _boulderService.UpdateBoulder(request);
            if (result is null)
            {
                return NotFound("Not Found");
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Boulder>>>? DeleteBoulder(int id)
        {
            var result = await _boulderService.DeleteBoulder(id);
            if (result is null)
            {
                return NotFound("Not Found");
            }
            return Ok(result);
        }
    }
}
