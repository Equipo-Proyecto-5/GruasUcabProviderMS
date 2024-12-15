using FluentValidation;
using ProviderMS.Commons.Dtos.Request.Grua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderMS.Application.Validators.Grua
{
    public class ModifyGruaValidator : ValidatorBase<ModifyGruaDto>
    {

        public ModifyGruaValidator() {


            RuleFor(p => p.Id)
              .NotEmpty()
              .WithMessage("El id de la grua es requerido");


            RuleFor(p => p.Marca)
               .NotEmpty()
               .WithMessage("La marca es requerida.");

            RuleFor(p => p.Modelo)
                .NotEmpty()
                .WithMessage("El modelo es requerido.");

            RuleFor(p => p.Año)
                .NotEmpty()
                .WithMessage("El año es requerido.");

            RuleFor(p => p.Placa)
                .NotEmpty()
                .WithMessage("La placa es requerida.");

            RuleFor(p => p.Color)
                .NotEmpty()
                .WithMessage("El color es requerido.");

        }
    }
}
