using ProviderMS.Domain.Entities;


namespace ProviderMS.Core.Repositories
{
    public interface IProveedorRepository
    {

        Task AddAsync(Proveedor proveedor);
    }
}
