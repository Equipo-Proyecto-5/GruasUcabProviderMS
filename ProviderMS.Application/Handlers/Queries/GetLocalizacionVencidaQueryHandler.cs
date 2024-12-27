using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ProviderMS.Application.Queries;
using ProviderMS.Core.Repositories;

namespace ProviderMS.Application.Handlers.Queries
{
    public class GetLocalizacionVencidaQueryHandler : IRequestHandler<GetLocalizacionVencidaQuery>
    {
        private readonly IGruaRepository _gruaRepository;

        public GetLocalizacionVencidaQueryHandler(IGruaRepository gruaRepository)
        {
            _gruaRepository = gruaRepository;
        }

        public async Task<Unit> Handle(GetLocalizacionVencidaQuery request, CancellationToken cancellationToken)
        {
            var gruas=  await _gruaRepository.GetAllAsyncGrua();
            

            foreach (var grua in gruas)
            {
                TimeSpan? diferenciaEntreTiempos = DateTime.UtcNow - grua.Hora;
                double? tiempoTranscurridoMinutos = diferenciaEntreTiempos?.TotalMinutes;

                if (tiempoTranscurridoMinutos > 10)
                {
                    grua.ActualizarEstatus("Inactivo");
                    await _gruaRepository.ModifyAsyncGrua(grua);
                }
            }
            return Unit.Value;

        }
    }
}
