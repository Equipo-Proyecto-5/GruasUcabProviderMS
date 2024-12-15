using AutoMapper;
using MediatR;
using ProviderMS.Application.Commands.Grua;
using ProviderMS.Application.Exceptions;
using ProviderMS.Application.Validators.Grua;
using ProviderMS.Core.Repositories;
using ProviderMS.Domain.Entities;

namespace ProviderMS.Application.Handlers.Commands.Gruas
{
    public class CreateGruaCommandHandler : IRequestHandler<CreateGruaCommand, bool>
    {

        private readonly IGruaRepository _gruaRepository;
        private readonly IMapper _mapper;


        public CreateGruaCommandHandler(IGruaRepository gruaRepository, IMapper mapper)
        {
            _gruaRepository = gruaRepository;
            _mapper = mapper;
        }


        public async Task<bool> Handle(CreateGruaCommand request, CancellationToken cancellationToken)
        {
            // Valida el DTO de la grua
            var validator = new CreateGruaValidator();
            await validator.ValidateRequest(request.Grua);

            // Verifica si la grua ya existe
            bool gruaExiste = await _gruaRepository.IsGruaExistingAsync(
                request.Grua.Placa);

            if (gruaExiste)
            {
                throw new ValidatorException("La grua ya cuenta con registro previo");
            }

            // Mapea el DTO a la entidad Grua
            var grua = _mapper.Map<Grua>(request.Grua);


            // Asignar el ProveedorId recibido desde el frontend (si se ha seleccionado un proveedor)
            if (request.Grua.ProveedorId.HasValue)
            {
                grua.ProveedorId = request.Grua.ProveedorId.Value;
            }


            // Guarda la nueva grua en el repositorio
            await _gruaRepository.AddAsyncGrua(grua);
            return true; // Retorna 'true' si la operación fue exitosa
        }

    }
}
