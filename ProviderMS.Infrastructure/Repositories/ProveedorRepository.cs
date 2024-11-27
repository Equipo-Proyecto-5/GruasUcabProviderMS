using Microsoft.EntityFrameworkCore;
using ProviderMS.Core.Repositories;
using ProviderMS.Domain.Entities;
using ProviderMS.Infrastructure.Database;


namespace ProviderMS.Infrastructure.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly ProviderDbContext db_context;

        public ProveedorRepository(ProviderDbContext context)
        {
            db_context = context;
        }

        public async Task AddAsync(Proveedor proveedor)
        {
            await db_context.Proveedor.AddAsync(proveedor);
            await db_context.SaveChangesAsync();
        }

        public async Task<bool> IsProveedorExistingAsync(string numeroDocumentoIdentidad)
        {
            return await db_context.Proveedor.AnyAsync(p => p.NumeroDocumentoIdentidad == numeroDocumentoIdentidad);
        }

        public async Task<IEnumerable<Proveedor>> GetAllAsync()
        {
            return await db_context.Proveedor.ToListAsync();
        }

        public async Task ModifyAsyncProvider<T>(T proveedor) where T : Proveedor
        {

            var existingProvider = await db_context.Proveedor.FindAsync(proveedor.Id);
            if (existingProvider == null)
            {
                throw new KeyNotFoundException("La empresa proveedora no se encontró.");
            }

            db_context.Entry(existingProvider).CurrentValues.SetValues(proveedor);
            await db_context.SaveChangesAsync();
        }
    }
}
