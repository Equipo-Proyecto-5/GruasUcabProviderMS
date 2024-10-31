using MediatR;
using ProviderMS.Core.Repositories;
using ProviderMS.Commons.Dtos.Respose;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ProviderMS.Application.Queries;
using ProviderMS.Commons.Dtos.Respose;
using ProviderMS.Core.Repositories;

namespace ProviderMS.Application.Handlers
{
    public class GetProveedorQueryHandler : IRequestHandler<GetProveedorQuery, List<GetProveedorDto>>
    {
        private readonly IProveedorRepository _proveedorRepository;

        public GetProveedorQueryHandler(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        public async Task<List<GetProveedorDto>> Handle(GetProveedorQuery request, CancellationToken cancellationToken)
        {
            var proveedores = await _proveedorRepository.GetAllAsync();

            return proveedores.Select(proveedor => new GetProveedorDto
            {
                Id = proveedor.Id,
                DenominacionComercial = proveedor.DenominacionComercial,
                RazonSocial = proveedor.RazonSocial,
                DireccionFisica = proveedor.DireccionFisica,
                TipoDocumentoIdentidad = proveedor.TipoDocumentoIdentidad,
                NumeroDocumentoIdentidad = proveedor.NumeroDocumentoIdentidad,
                Estatus = proveedor.Estatus
            }).ToList();
        }


    }
}



