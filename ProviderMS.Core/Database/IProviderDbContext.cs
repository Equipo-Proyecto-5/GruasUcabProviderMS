using Microsoft.EntityFrameworkCore;
using ProviderMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ProviderMS.Core.Database
{
    public interface IProviderDbContext
    {
        DbContext DbContext { get; }

        DbSet<Proveedor> Proveedor { get; set; }
        DbSet<Grua> Grua { get; set; }

    }
}
