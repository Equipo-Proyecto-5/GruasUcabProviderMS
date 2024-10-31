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

        public async Task<IEnumerable<Proveedor>> GetAllAsync()
        {
            return await db_context.Proveedor.ToListAsync();
        }
    }
}
