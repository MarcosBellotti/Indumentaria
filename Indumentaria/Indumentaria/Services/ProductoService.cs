using AutoMapper;
using Indumentaria.DTOs;
using Indumentaria.Models;
using Indumentaria.Repository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Indumentaria.Services
{
    public class ProductoService : ICrud<ProductoDTO, ProductoInsertDTO, ProductoUpdateDTO>
    {
        private IRepository<Producto> _productoRepository;
        private IRepository<Marca> _marcaRepository;
        private IRepository<TipoDeProducto> _tipoDeProductoRepository;
        private IMapper _autoMapper;

        public ProductoService([FromKeyedServices("ProductoRepository")] IRepository<Producto> productoRepository, 
            IMapper autoMapper,
            [FromKeyedServices("MarcaRepository")]  IRepository<Marca> marcaRepository,
            [FromKeyedServices("TipoDeProductoRepository")] IRepository<TipoDeProducto> tipoDeProductoRepository)
        {
            _productoRepository = productoRepository;
            _autoMapper = autoMapper;
            _marcaRepository = marcaRepository;
            _tipoDeProductoRepository = tipoDeProductoRepository;
        }
        public async Task<IEnumerable<ProductoDTO>> Get()
        {
            var productos = await _productoRepository.Get();
            return productos.Select(b => _autoMapper.Map<ProductoDTO>(b));
        }

        public async Task<ProductoDTO> GetById(int id)
        {
            var producto = await _productoRepository.GetById(id);

            return producto != null ? _autoMapper.Map<ProductoDTO>(producto) : null;
        }

        public async Task<ProductoDTO> Add(ProductoInsertDTO insertDTO)
        {
            if(await _marcaRepository.GetById(insertDTO.MarcaId)==null)
            {
                throw new InvalidOperationException("El id de la marca especificada no existe en la base de datos.");
            }

            if (await _tipoDeProductoRepository.GetById(insertDTO.TipoDeProductoId) == null)
            {
                throw new InvalidOperationException("El id del tipo de producto especificado no existe en la base de datos.");
            }

            var producto = _autoMapper.Map<Producto>(insertDTO);

            await _productoRepository.Add(producto);
            await _productoRepository.Save();

            return _autoMapper.Map<ProductoDTO>(producto);
        }

        public async Task<ProductoDTO> Update(int id, ProductoUpdateDTO updateDTO)
        {
            var producto = await _productoRepository.GetById(id);

            if(producto != null)
            {
                if (await _marcaRepository.GetById(updateDTO.MarcaId) == null)
                {
                    throw new InvalidOperationException("El id de la marca especificada no existe en la base de datos.");
                }

                if (await _tipoDeProductoRepository.GetById(updateDTO.TipoDeProductoId) == null)
                {
                    throw new InvalidOperationException("El id del tipo de producto especificado no existe en la base de datos.");
                }

                producto = _autoMapper.Map<ProductoUpdateDTO, Producto>(updateDTO, producto);

                _productoRepository.Update(producto);
                _productoRepository.Save();

                return _autoMapper.Map<ProductoDTO>(producto);
            }

            return null;
        }
        public async Task<ProductoDTO> Delete(int id)
        {
            var producto = await _productoRepository.GetById(id);

            if (producto != null)
            {
                _productoRepository.Delete(producto);
                _productoRepository.Save();

                return _autoMapper.Map<ProductoDTO>(producto);
            }

            return null;
        }
    }
}
