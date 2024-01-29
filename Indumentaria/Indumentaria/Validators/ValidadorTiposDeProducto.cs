using FluentValidation;
using Indumentaria.DTOs;

namespace Indumentaria.Validators
{
    public class ValidadorTiposDeProductoInsertDTO : AbstractValidator<TipoDeProductoInsertDTO>
    {
        public ValidadorTiposDeProductoInsertDTO()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El {PropertyName} del producto no puede estar vacio");
            RuleFor(x => x.Descripcion).NotEmpty().WithMessage("La {PropertyName} del producto no puede estar vacia");
            RuleFor(x => x.Nombre).Length(3,20).WithMessage("El {PropertyName} del producto debe tener entre 3 y 20 letras");
        }
    }
}
