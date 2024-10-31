using AutoMapper;
using MediatR;
using ProviderMS.Application.Commands;
using ProviderMS.Domain.Entities;
using ProviderMS.Core.Repositories;
using ProviderMS.Application.Validators;
using ProviderMS.Application.Exceptions;

namespace ProviderMS.Application.Handlers
{
    public class CreateProveedorCommandHandler : IRequestHandler<CreateProveedorCommand, bool>
    {
        private readonly IProveedorRepository _proveedorRepository;
        private readonly IMapper _mapper;

        public CreateProveedorCommandHandler(IProveedorRepository proveedorRepository, IMapper mapper)
        {
            _proveedorRepository = proveedorRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateProveedorCommand request, CancellationToken cancellationToken)
        {
            // Valida el DTO del proveedor
            var validator = new CreateProveedorValidator();
            await validator.ValidateRequest(request.Proveedor);

            // Verifica si el proveedor ya existe
            bool proveedorExiste = await _proveedorRepository.IsProveedorExistingAsync(
                request.Proveedor.NumeroDocumentoIdentidad);

            if (proveedorExiste)
            {
                throw new ValidatorException("El proveedor ya cuenta con registro previo");
            }

            // Mapea el DTO a la entidad Proveedor
            var proveedor = _mapper.Map<Proveedor>(request.Proveedor);

            

            // Guarda el nuevo proveedor en el repositorio
            await _proveedorRepository.AddAsync(proveedor);
            return true; // Retorna 'true' si la operación fue exitosa
        }
    }
}
