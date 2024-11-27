using AutoMapper;
using MediatR;
using ProviderMS.Application.Commands;
using ProviderMS.Application.Exceptions;
using ProviderMS.Application.Validators;
using ProviderMS.Core.Repositories;
using ProviderMS.Domain.Entities;


namespace ProviderMS.Application.Handlers.Commands
{
    public class ModifyProveedorCommandHandler : IRequestHandler<ModifyProveedorCommand,Unit>
    {
        private readonly IProveedorRepository _proveedorRepository;
        private readonly IMapper _mapper;

        public ModifyProveedorCommandHandler(IProveedorRepository proveedorRepository, IMapper mapper)
        {
            _proveedorRepository = proveedorRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(ModifyProveedorCommand request, CancellationToken cancellationToken)
        {
            
            var validator = new ModifyProveedorValidator();
            await validator.ValidateRequest(request.ModifyProveedor);

         
            var proveedores = await _proveedorRepository.GetAllAsync();
            var proveedorExistente = proveedores.FirstOrDefault(p => p.NumeroDocumentoIdentidad == request.ModifyProveedor.NumeroDocumentoIdentidad);

            if (proveedorExistente != null && proveedorExistente.Id != request.ModifyProveedor.Id)
            {
                throw new ValidatorException("El proveedor ya cuenta con registro previo");
            }

            
            var proveedor = _mapper.Map<Proveedor>(request.ModifyProveedor);

         
            await _proveedorRepository.ModifyAsyncProvider(proveedor);

            return Unit.Value;
        }



    }
}






