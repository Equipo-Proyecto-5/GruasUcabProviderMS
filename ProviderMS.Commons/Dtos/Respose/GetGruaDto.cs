

namespace ProviderMS.Commons.Dtos.Respose
{
    public class GetGruaDto
    {
        public Guid? ProveedorId { get; set; }
        public Guid Id { get; set; }
        public string Tipo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Año { get; set; }
        public string Placa { get; set; }
        public string Color { get; set; }
        public string Estatus { get; set; }
    }
}
