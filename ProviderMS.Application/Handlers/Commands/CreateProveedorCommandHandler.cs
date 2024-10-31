using MediatR;
using ProviderMS.Application.Commands;
using ProviderMS.Domain.Entities;
using ProviderMS.Core.Repositories;

namespace ProviderMS.Application.Handlers
{
    public class CreateProveedorCommandHandler : IRequestHandler<CreateProveedorCommand, Guid>
    {
        private readonly IProveedorRepository _proveedorRepository;

        public CreateProveedorCommandHandler(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        public async Task<Guid> Handle(CreateProveedorCommand request, CancellationToken cancellationToken)
        {
            var proveedor = new Proveedor(
                Guid.NewGuid(),
                request.Proveedor.DenominacionComercial,
                request.Proveedor.RazonSocial,
                request.Proveedor.DireccionFisica,
                request.Proveedor.TipoDocumentoIdentidad,
                request.Proveedor.NumeroDocumentoIdentidad,
                request.Proveedor.Estatus
            );

            await _proveedorRepository.AddAsync(proveedor);
            return proveedor.Id;
        }
    }
}
