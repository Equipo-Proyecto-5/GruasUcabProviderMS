using MediatR;
using ProviderMS.Application.Commands.Grua;
using ProviderMS.Core.Repositories;
namespace ProviderMS.Application.Handlers.Commands.Gruas
{
    public class DeleteGruaCommandHandler : IRequestHandler<DeleteGruaCommand, Unit>
    {
        private readonly IGruaRepository _gruaRepository;

        public DeleteGruaCommandHandler(IGruaRepository gruaRepository)
        {
            _gruaRepository = gruaRepository;
        }
        public async Task<Unit> Handle(DeleteGruaCommand request, CancellationToken cancellationToken)
        {
            await _gruaRepository.DeleteAsyncGrua(request.Id);
            return Unit.Value;
        }
    }
}
