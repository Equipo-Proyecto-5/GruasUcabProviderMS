using MediatR;


namespace ProviderMS.Application.Commands
{
    public class DeleteProveedorCommand : IRequest
    {

        public DeleteProveedorCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
