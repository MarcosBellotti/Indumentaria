using AutoMapper;
using Indumentaria.DTOs;
using Indumentaria.Models;

namespace Indumentaria.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TipoDeProductoInsertDTO, TipoDeProducto>();
            CreateMap<TipoDeProducto, TipoDeProductoDTO>();
            CreateMap<TipoDeProductoUpdateDTO, TipoDeProducto>();

            CreateMap<ProductoInsertDTO, Producto>();
            CreateMap<Producto, ProductoDTO>();
            CreateMap<ProductoUpdateDTO, Producto>();

            CreateMap<MarcaInsertDTO, Marca>();
            CreateMap<Marca, MarcaDTO>();
            CreateMap<MarcaUpdateDTO, Marca>();

            CreateMap<ProveedorInsertDTO, Proveedor>();
            CreateMap<Proveedor, ProveedorDTO>();
            CreateMap<ProveedorUpdateDTO, Proveedor>();
        }
    }
}
