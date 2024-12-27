using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ProviderMS.Application.Queries;
using ProviderMS.Commons.Dtos.Respose;
using ProviderMS.Core.Repositories;

namespace ProviderMS.Application.Handlers.Queries
{
    public class GetGruaUbicacionQueryHandler : IRequestHandler<GetGruasUbicacionQuery, List<GetGruaUbicacionDto>>
    {
        private readonly IGruaRepository _gruaRepository;

        public GetGruaUbicacionQueryHandler(IGruaRepository gruaRepository)
        {
            _gruaRepository = gruaRepository;
        }

        public async  Task<List<GetGruaUbicacionDto>> Handle(GetGruasUbicacionQuery request, CancellationToken cancellationToken)
        {
            var gruas = await _gruaRepository.GetAllAsyncGrua();
            return gruas.Select(grua => new GetGruaUbicacionDto(grua.Id,grua.Tipo,grua.Marca,grua.Modelo,grua.Placa,grua.Color, grua.Latitud.Value,grua.Longitud.Value) ).ToList();
        }
    }
}
