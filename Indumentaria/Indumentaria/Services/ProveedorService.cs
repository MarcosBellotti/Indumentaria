using AutoMapper;
using Indumentaria.DTOs;
using Indumentaria.Models;
using Indumentaria.Repository;

namespace Indumentaria.Services
{
    public class ProveedorService : ICrud<ProveedorDTO, ProveedorInsertDTO, ProveedorUpdateDTO>
    {
        private IMapper _autoMapper;
        private IRepository<Proveedor> _proveedorRepository;
        public ProveedorService([FromKeyedServices("ProveedorRepository")] IRepository<Proveedor> proveedorRepository,
            IMapper autoMapper)
        {
            _proveedorRepository = proveedorRepository;
            _autoMapper = autoMapper;
        }
        public async Task<IEnumerable<ProveedorDTO>> Get()
        {
            var proveedores = await _proveedorRepository.Get();
            return proveedores.Select(b => _autoMapper.Map<ProveedorDTO>(b));
        }

        public async Task<ProveedorDTO> GetById(int id)
        {
            var proveedor = await _proveedorRepository.GetById(id);
            return proveedor != null ? _autoMapper.Map<ProveedorDTO>(proveedor) : null;
        }
        public async Task<ProveedorDTO> Add(ProveedorInsertDTO insertDTO)
        {
            var proveedores = await _proveedorRepository.Get();
            foreach (var unProveedor in proveedores)
                if(unProveedor.Cuit == insertDTO.Cuit)
                    throw new InvalidOperationException("El cuit del proveedor ya existe");

            var proveedor = _autoMapper.Map<Proveedor>(insertDTO);

            await _proveedorRepository.Add(proveedor);
            await _proveedorRepository.Save();

            return _autoMapper.Map<ProveedorDTO>(proveedor);
        }        

        public async Task<ProveedorDTO> Update(int id, ProveedorUpdateDTO updateDTO)
        {
            var proveedor = await _proveedorRepository.GetById(id);
            if(proveedor != null)
            {
                proveedor = _autoMapper.Map<ProveedorUpdateDTO, Proveedor>(updateDTO, proveedor);

                _proveedorRepository.Update(proveedor);
                await _proveedorRepository.Save();

                return _autoMapper.Map<ProveedorDTO>(proveedor);
            }
            return null;
        }
        public async Task<ProveedorDTO> Delete(int id)
        {
            var proveedor = await _proveedorRepository.GetById(id);
            if (proveedor != null)
            { 
                _proveedorRepository.Delete(proveedor);
                await _proveedorRepository.Save();

                return _autoMapper.Map<ProveedorDTO>(proveedor);
            }
            return null;
        }
    }
}
