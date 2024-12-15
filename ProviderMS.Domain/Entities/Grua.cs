

namespace ProviderMS.Domain.Entities
{
    public class Grua : Vehiculo
    {
        public string Tipo { get; private set; }
        public Guid? ProveedorId { get;  set; }
        public Proveedor Proveedor { get; set; }
    }
}
