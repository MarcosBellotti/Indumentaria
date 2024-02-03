using Indumentaria.DTOs;
using Indumentaria.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Indumentaria.Controllers
{
    [Route("Producto/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private ICrud<ProductoDTO, ProductoInsertDTO, ProductoUpdateDTO> _productoCrud;
        public ProductoController([FromKeyedServices("ProductoService")] ICrud<ProductoDTO, ProductoInsertDTO, ProductoUpdateDTO> productoCrud)
        {
            _productoCrud = productoCrud;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductoDTO>> Get()
            => await _productoCrud.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDTO>> GetById(int id)
        {
            var productoDTO = await _productoCrud.GetById(id);

            return productoDTO != null ? Ok(productoDTO) : NotFound();   
        }

        [HttpPost]
        public async Task<ActionResult<ProductoDTO>> Add(ProductoInsertDTO productoInsertDTO)
        {
            try
            {
                var productoDTO = await _productoCrud.Add(productoInsertDTO);

                return CreatedAtAction(nameof(GetById), new { id = productoDTO.ProductoId }, productoDTO);
            }
            catch (InvalidOperationException ex)
            {
                // Manejar la excepción específica para MarcaId o TipoDeProductoId no existentes
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductoDTO>> Update(int id, ProductoUpdateDTO productoUpdateDTO)
        {
            try
            {
                var productoDTO = await _productoCrud.Update(id, productoUpdateDTO);

                return productoDTO != null ? Ok(productoDTO) : NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductoDTO>> Delete(int id)
        {
            var productoDTO = await _productoCrud.Delete(id);

            return productoDTO != null ? Ok(productoDTO) : NotFound();
        }

    }
}
