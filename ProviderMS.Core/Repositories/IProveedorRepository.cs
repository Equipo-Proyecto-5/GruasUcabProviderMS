using ProviderMS.Domain.Entities;


namespace ProviderMS.Core.Repositories
{
    public interface IProveedorRepository
    {

        Task AddAsync(Proveedor proveedor);
        Task<bool> IsProveedorExistingAsync(string NumeroDocumentoIdentidad);

        Task<IEnumerable<Proveedor>> GetAllAsync();
    }
}
