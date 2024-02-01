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
        private IMapper _autoMapper;
        public ProductoService([FromKeyedServices("ProductoRepository")] IRepository<Producto> productoRepository, 
            IMapper autoMapper)
        {
            _productoRepository = productoRepository;
            _autoMapper = autoMapper;
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
                producto = _autoMapper.Map<ProductoUpdateDTO, Producto>(updateDTO);

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
