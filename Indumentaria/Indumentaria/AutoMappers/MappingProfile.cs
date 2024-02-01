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
        }
    }
}
