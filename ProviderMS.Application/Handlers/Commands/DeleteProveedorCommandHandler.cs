using MediatR;
using ProviderMS.Application.Commands;
using ProviderMS.Core.Repositories;



namespace ProviderMS.Application.Handlers.Commands
{
    public class DeleteProveedorCommandHandler : IRequestHandler<DeleteProveedorCommand, Unit>
    {

        private readonly IProveedorRepository _proveedorRepository;

        public DeleteProveedorCommandHandler(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }
        public async Task<Unit> Handle(DeleteProveedorCommand request, CancellationToken cancellationToken)
        {
            await _proveedorRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }

    }
}
