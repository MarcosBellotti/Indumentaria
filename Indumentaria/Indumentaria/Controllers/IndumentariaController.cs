using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Indumentaria.Controllers
{
    [Route("indumentaria/[controller]")]
    [ApiController]
    public class IndumentariaController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}
