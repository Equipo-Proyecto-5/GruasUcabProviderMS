using MediatR;
using ProviderMS.Commons.Dtos.Respose;
using ProviderMS.Core.Repositories;
using ProviderMS.Application.Queries;

namespace ProviderMS.Application.Handlers.Queries
{
    public class GetGruaQuerieHandler : IRequestHandler<GetGruaQuery, List<GetGruaDto>>
    {

        private readonly IGruaRepository _gruaRepository;

        public GetGruaQuerieHandler(IGruaRepository gruaRepository)
        {
            _gruaRepository = gruaRepository;
        }

        public async Task<List<GetGruaDto>> Handle(GetGruaQuery request, CancellationToken cancellationToken)
        {
            var gruas = await _gruaRepository.GetAllAsyncGrua();

            return gruas.Select(grua => new GetGruaDto
            {
                ProveedorId = grua.ProveedorId,
                Id = grua.Id,
                Tipo = grua.Tipo,
                Placa = grua.Placa,
                Marca = grua.Marca,
                Modelo = grua.Modelo,
                Color = grua.Color,
                Año = grua.Año,
                Estatus = grua.Estatus,
                DenominacionComercial = grua.Proveedor.DenominacionComercial // Mapear el nombre del proveedor
            }).ToList();
        }
    }
}
