using MediatR;


namespace ProviderMS.Application.Commands.Grua
{
    public class DeleteGruaCommand : IRequest
    {

        public DeleteGruaCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
