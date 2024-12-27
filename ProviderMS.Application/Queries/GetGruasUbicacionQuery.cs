using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ProviderMS.Commons.Dtos.Respose;

namespace ProviderMS.Application.Queries
{
    public class GetGruasUbicacionQuery:IRequest<List<GetGruaUbicacionDto>>
    {

    }
}
