using MediatR;
using ProviderMS.Commons.Dtos.Request.Grua;

namespace ProviderMS.Application.Commands.Grua
{
    public class ModifyGruaCommand : IRequest
    {

        public ModifyGruaDto ModifyGrua { get; set; }
        public Guid Id { get; set; }

        public ModifyGruaCommand(ModifyGruaDto modifyGrua, Guid id)
        {
            ModifyGrua = modifyGrua;
            Id = id;
        }
    }
}
