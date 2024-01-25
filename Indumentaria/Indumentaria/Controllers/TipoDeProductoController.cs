using Indumentaria.DTOs;
using Indumentaria.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Indumentaria.Controllers
{
    [Route("TipoDeProducto/[controller]")]
    [ApiController]
    public class TipoDeProductoController : ControllerBase
    {
        private ICrud<TipoDeProductoDTO, TipoDeProductoInsertDTO, TipoDeProductoUpdateDTO> _tipoDeProductoCrud;
        public TipoDeProductoController([FromKeyedServices("TipoDeProductoService")] ICrud<TipoDeProductoDTO, TipoDeProductoInsertDTO, TipoDeProductoUpdateDTO> tipoDeProductoCrud)
        {
            _tipoDeProductoCrud = tipoDeProductoCrud;
        }

        [HttpGet]
        public async Task<IEnumerable<TipoDeProductoDTO>> Get()
            => await _tipoDeProductoCrud.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDeProductoDTO>> GetById(int id)
        {
            var tipoDeProductoDTO = await _tipoDeProductoCrud.GetById(id);

            return tipoDeProductoDTO != null ? Ok(tipoDeProductoDTO) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<TipoDeProductoDTO>> Add(TipoDeProductoInsertDTO tipoDeProductoInsertDTO)
        {
            var tipoDeProductoDTO = await _tipoDeProductoCrud.Add(tipoDeProductoInsertDTO);

            return CreatedAtAction(nameof(GetById), new {id = tipoDeProductoDTO.TipoDeProductoId}, tipoDeProductoDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TipoDeProductoDTO>> Update(int id, TipoDeProductoUpdateDTO tipoDeProductoUpdateDTO )
        {
            var tipoDeProductoDTO = await _tipoDeProductoCrud.Update(id, tipoDeProductoUpdateDTO);

            return tipoDeProductoUpdateDTO != null ? Ok(tipoDeProductoUpdateDTO) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoDeProductoDTO>> Delete(int id)
        {
            var tipoDeProductoDTO = await _tipoDeProductoCrud.Delete(id);

            return tipoDeProductoDTO != null ? Ok(tipoDeProductoDTO) : NotFound();
        }
    }
}
