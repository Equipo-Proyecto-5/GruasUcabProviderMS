using FluentValidation;
using ProviderMS.Commons.Dtos.Request;

namespace ProviderMS.Application.Validators
{
    public class ModifyProveedorValidator : ValidatorBase<ModifyProveedorDto>
    {
        public ModifyProveedorValidator()
        {

            RuleFor(p => p.Id)
                .NotEmpty()
                .WithMessage("El id del proveedor es requerido.");

            RuleFor(p => p.DenominacionComercial)
                .NotEmpty()
                .WithMessage("La denominación comercial es requerida.");

            RuleFor(p => p.RazonSocial)
                .NotEmpty()
                .WithMessage("La razón social es requerida.");

            RuleFor(p => p.DireccionFisica)
                .NotEmpty()
                .WithMessage("La dirección física es requerida.");

            RuleFor(p => p.TipoDocumentoIdentidad)
                .NotEmpty()
                .WithMessage("El tipo de documento de identidad es requerido.");

            RuleFor(p => p.NumeroDocumentoIdentidad)
                .NotEmpty()
                .WithMessage("El número del documento de identidad es requerido.");
        }
    }
    
}
