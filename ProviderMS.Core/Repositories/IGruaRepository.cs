using ProviderMS.Domain.Entities;

namespace ProviderMS.Core.Repositories
{
    public interface IGruaRepository
    {
        Task AddAsyncGrua(Grua grua);

        Task<bool> IsGruaExistingAsync(string Placa);

        Task<IEnumerable<Grua>> GetAllAsyncGrua();

        Task ModifyAsyncGrua<T>(T grua) where T : Grua;

        Task DeleteAsyncGrua(Guid Id);

    }
}
