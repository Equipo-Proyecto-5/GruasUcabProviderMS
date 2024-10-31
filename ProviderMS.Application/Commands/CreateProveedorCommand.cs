using MediatR;
using ProviderMS.Commons.Dtos.Request;


namespace ProviderMS.Application.Commands
{
    public class CreateProveedorCommand : IRequest<Guid>
    {
        public CreateProveedorDto Proveedor { get; set; }

        public CreateProveedorCommand(CreateProveedorDto proveedor)
        {
            Proveedor = proveedor;
        }
    }
}
