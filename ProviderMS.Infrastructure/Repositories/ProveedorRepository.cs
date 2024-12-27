using Microsoft.EntityFrameworkCore;
using ProviderMS.Core.Database;
using ProviderMS.Core.Repositories;
using ProviderMS.Domain.Entities;
using ProviderMS.Infrastructure.Database;


namespace ProviderMS.Infrastructure.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly IProviderDbContext db_context;

        public ProveedorRepository(IProviderDbContext context)
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

            db_context.Proveedor.Entry(existingProvider).CurrentValues.SetValues(proveedor);
            await db_context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var usuarioEncontrado = await db_context.Proveedor.FindAsync(id);
            if (usuarioEncontrado is null) throw new InvalidOperationException("Proveedor no encontrado");

            usuarioEncontrado.ActualizarEstatus("Inactivo");
            db_context.Proveedor.Entry(usuarioEncontrado).Property(o => o.Estatus).IsModified = true;
            await db_context.SaveChangesAsync();
        }
    }
}
