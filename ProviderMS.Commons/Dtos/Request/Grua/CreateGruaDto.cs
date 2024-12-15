
namespace ProviderMS.Commons.Dtos.Request.Grua
{
    public class CreateGruaDto
    {
        public Guid? ProveedorId { get; set; }
        public string Tipo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Año { get; set; }
        public string Placa { get; set; }
        public string Color { get; set; }
    }
}
