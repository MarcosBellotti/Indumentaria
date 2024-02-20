using Indumentaria.DTOs;
using Indumentaria.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Indumentaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private ICrud<ProveedorDTO, ProveedorInsertDTO, ProveedorUpdateDTO> _proveedorCrud;
        public ProveedorController([FromKeyedServices("ProveedorService")] ICrud<ProveedorDTO, ProveedorInsertDTO, ProveedorUpdateDTO> proveedorCrud)
        {
            _proveedorCrud = proveedorCrud;
        }

        [HttpGet]
        public async Task<IEnumerable<ProveedorDTO>> Get()
            => await _proveedorCrud.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<ProveedorDTO>> GetById(int id)
        {
            var proveedorDTO = await _proveedorCrud.GetById(id);

            return proveedorDTO != null ? Ok(proveedorDTO) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<ProveedorDTO>> Add(ProveedorInsertDTO proveedorInsertDTO)
        {
            try
            {
                var proveedorDTO = await _proveedorCrud.Add(proveedorInsertDTO);

                return CreatedAtAction(nameof(GetById), new { cuit = proveedorDTO.Cuit }, proveedorDTO);
            }
            catch (InvalidOperationException ex)
            {
                //ver si ya existe el cuit del proveedor
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProveedorDTO>> Update(int id, ProveedorUpdateDTO proveedorUpdateDTO)
        {
            var proveedorDTO = await _proveedorCrud.Update(id, proveedorUpdateDTO);

            return proveedorDTO != null ? Ok(proveedorDTO) : NotFound();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MarcaDTO>> Delete(int id)
        {
            var proveedorDTO = await _proveedorCrud.Delete(id);

            return proveedorDTO != null ? Ok(proveedorDTO) : NotFound();
        }

    }
}
