using AutoMapper;
using Indumentaria.DTOs;
using Indumentaria.Models;
using Indumentaria.Repository;

namespace Indumentaria.Services
{
    public class MarcaService : ICrud<MarcaDTO, MarcaInsertDTO, MarcaUpdateDTO>
    {
        private IMapper _autoMapper;
        private IRepository<Marca> _marcaRepository;
        public MarcaService([FromKeyedServices("MarcaRepository")] IRepository<Marca> marcaRepository,
            IMapper autoMapper)
        {
            _marcaRepository = marcaRepository;
            _autoMapper = autoMapper;
        }

        public async Task<IEnumerable<MarcaDTO>> Get()
        {
            var marcas = await _marcaRepository.Get();
            return marcas.Select(b => _autoMapper.Map<MarcaDTO>(b));
        }

        public async Task<MarcaDTO> GetById(int id)
        {
            var marca = await _marcaRepository.GetById(id);

            return marca != null ? _autoMapper.Map<MarcaDTO>(marca) : null;
        }
        public async Task<MarcaDTO> Add(MarcaInsertDTO marcaInsertDTO)
        {
            var marca = _autoMapper.Map<Marca>(marcaInsertDTO);

            var marcas = await Get();

            foreach (var marcaBuscada in marcas)
            {
                if (marcaBuscada.Nombre == marca.Nombre)
                {
                    throw new InvalidOperationException("La marca ya existe.");
                }
            }

            await _marcaRepository.Add(marca);
            await _marcaRepository.Save();

            return _autoMapper.Map<MarcaDTO>(marca);
        }
        public async Task<MarcaDTO> Update(int id, MarcaUpdateDTO marcaUpdateDTO)
        {
            var marca = await _marcaRepository.GetById(id);
            if(marca != null)
            {
                var marcas = await Get();

                foreach (var marcaBuscada in marcas)
                {
                    if (marcaBuscada.Nombre == marcaUpdateDTO.Nombre && marcaBuscada.MarcaId != id)
                    {
                        throw new InvalidOperationException("La marca que quiere actualizar ya existe.");
                    }
                }

                marca = _autoMapper.Map<MarcaUpdateDTO, Marca>(marcaUpdateDTO, marca);

                _marcaRepository.Update(marca);
                await _marcaRepository.Save();

                return _autoMapper.Map<MarcaDTO>(marca);
            }

            return null;
        }
        public async Task<MarcaDTO> Delete(int id)
        {
            var marca = await _marcaRepository.GetById(id);
            if(marca!=null)
            {
                _marcaRepository.Delete(marca);
                await _marcaRepository.Save();

                return _autoMapper.Map<MarcaDTO>(marca);
            }
            return null;
        }
    }
}
