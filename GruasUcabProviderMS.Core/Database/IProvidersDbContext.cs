using Microsoft.EntityFrameworkCore;
using ProviderMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GruasUcabProviderMS.Core.Database
{
    public interface IProvidersDbContext
    {
        DbContext DbContext { get; }

        DbSet<Proveedor> Proveedor { get; set; }

       // IDbContextTransactionProxy BeginTransaction();

       // void ChangeEntityState<TEntity>(TEntity entity, EntityState state);

       // Task<bool> SaveEfContextChanges(string user, CancellationToken cancellationToken = default);
    }
}
