using AutoMapper;
using Indumentaria.DTOs;
using Indumentaria.Models;
using Indumentaria.Repository;

namespace Indumentaria.Services
{
    public class TipoDeProductoService : ICrud<TipoDeProductoDTO, TipoDeProductoInsertDTO, TipoDeProductoUpdateDTO>
    {
        private IMapper _autoMapper;
        private IRepository<TipoDeProducto> _tipoDeProductoRepository;

        public TipoDeProductoService(IMapper autoMapper,
            [FromKeyedServices("TipoDeProductoRepository")] IRepository<TipoDeProducto> tipoDeProductoRepository)
        {
            _autoMapper = autoMapper;
            _tipoDeProductoRepository = tipoDeProductoRepository;
        }
        public async Task<IEnumerable<TipoDeProductoDTO>> Get()
        {
            var tiposDeProducto = await _tipoDeProductoRepository.Get();

            return tiposDeProducto.Select(b => _autoMapper.Map<TipoDeProductoDTO>(b));
        }

        public async Task<TipoDeProductoDTO> GetById(int id)
        {
            var tipoDeProducto = await _tipoDeProductoRepository.GetById(id);

            if(tipoDeProducto != null)
            {
                var tipoDeProductoDTO = _autoMapper.Map<TipoDeProductoDTO>(tipoDeProducto);
                return tipoDeProductoDTO;
            }

            return null;
        }
        public async Task<TipoDeProductoDTO> Add(TipoDeProductoInsertDTO tipoDeProductoInsertDTO)
        {
            TipoDeProducto tipoDeProducto = _autoMapper.Map<TipoDeProducto>(tipoDeProductoInsertDTO);

            await _tipoDeProductoRepository.Add(tipoDeProducto);
            await _tipoDeProductoRepository.Save();

            var tipoDeProductoDTO = _autoMapper.Map<TipoDeProductoDTO>(tipoDeProducto);

            return tipoDeProductoDTO;
        }

        public async Task<TipoDeProductoDTO> Update(int id, TipoDeProductoUpdateDTO tipoDeProductoUpdateDTO)
        {
            var tipoDeProducto = await _tipoDeProductoRepository.GetById(id);

            if (tipoDeProducto != null)
            {
                //Actualizo los valores que me llegaron modificados del objeto parametro, y los que no, se quedan igual
                tipoDeProducto = _autoMapper.Map<TipoDeProductoUpdateDTO, TipoDeProducto>(tipoDeProductoUpdateDTO, tipoDeProducto);

                _tipoDeProductoRepository.Update(tipoDeProducto);
                await _tipoDeProductoRepository.Save();

                var tipoDeProductoDTO = _autoMapper.Map<TipoDeProductoDTO>(tipoDeProducto);

                return tipoDeProductoDTO;
            }

            return null;
        }

        public async Task<TipoDeProductoDTO> Delete(int id)
        {
            var tipoDeProducto = await _tipoDeProductoRepository.GetById(id);

            if (tipoDeProducto != null)
            {
                var tipoDeProductoDTO = _autoMapper.Map<TipoDeProductoDTO>(tipoDeProducto);

                _tipoDeProductoRepository.Delete(tipoDeProducto);
                await _tipoDeProductoRepository.Save();

                return tipoDeProductoDTO;
            }

            return null;
        }
    }
}
