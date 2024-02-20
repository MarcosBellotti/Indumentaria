using Indumentaria.DTOs;
using Indumentaria.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Indumentaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private ICrud<MarcaDTO, MarcaInsertDTO, MarcaUpdateDTO> _marcaCrud;
        public MarcaController([FromKeyedServices("MarcaService")] ICrud<MarcaDTO, MarcaInsertDTO, MarcaUpdateDTO> marcaCrud)
        {
            _marcaCrud = marcaCrud;
        }

        [HttpGet]
        public async Task<IEnumerable<MarcaDTO>> Get()
            => await _marcaCrud.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<MarcaDTO>> GetById(int id)
        {
            var marcaDTO = await _marcaCrud.GetById(id);

            return marcaDTO != null ? Ok(marcaDTO) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<MarcaDTO>> Add(MarcaInsertDTO marcaInsertDTO)
        {
            try
            {
                var marcaDTO = await _marcaCrud.Add(marcaInsertDTO);

                return CreatedAtAction(nameof(GetById), new { id = marcaDTO.MarcaId }, marcaDTO);
            }
            catch (InvalidOperationException ex)
            {
                // Manejar la excepción específica para ver si existe una marca con el nombre
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MarcaDTO>> Update(int id, MarcaUpdateDTO marcaUpdateDTO)
        {
            try
            {
                var marcaDTO = await _marcaCrud.Update(id, marcaUpdateDTO);

                return marcaDTO != null ? Ok(marcaDTO) : NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MarcaDTO>> Delete(int id)
        {
            var marcaDTO = await _marcaCrud.Delete(id);

            return marcaDTO != null ? Ok(marcaDTO) : NotFound();
        }
    }
}
