using ProviderMS.Commons.Dtos.Request.Grua;
using MediatR;


namespace ProviderMS.Application.Commands.Grua
{
    public class CreateGruaCommand : IRequest<bool>
    {

        public CreateGruaDto Grua { get; set; }

        public CreateGruaCommand(CreateGruaDto grua)
        {
            Grua = grua;
        }
    }
}
