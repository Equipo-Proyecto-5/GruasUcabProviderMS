using Microsoft.EntityFrameworkCore;
using ProviderMS.Core.Repositories;
using ProviderMS.Domain.Entities;
using ProviderMS.Infrastructure.Database;

namespace ProviderMS.Infrastructure.Repositories
{
    public class GruaRepository: IGruaRepository
    {

        private readonly ProviderDbContext db_context;

        public GruaRepository(ProviderDbContext context)
        {
            db_context = context;
        }

        public async Task AddAsyncGrua(Grua grua)
        {
            await db_context.Grua.AddAsync(grua);
            await db_context.SaveChangesAsync();
        }


        public async Task<bool> IsGruaExistingAsync(string placa)
        {
            return await db_context.Grua.AnyAsync(p => p.Placa == placa);
        }

    }
}
