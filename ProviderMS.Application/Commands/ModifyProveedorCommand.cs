using MediatR;
using ProviderMS.Commons.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderMS.Application.Commands
{
    public class ModifyProveedorCommand :IRequest
    {
        public ModifyProveedorDto ModifyProveedor { get; set; }
        public Guid Id { get; set; }

        public ModifyProveedorCommand(ModifyProveedorDto modifyProveedor, Guid id)
        {
            ModifyProveedor = modifyProveedor;
            Id = id;
        }

    }
}
