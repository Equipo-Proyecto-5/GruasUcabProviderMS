namespace ProviderMS.Commons.Dtos.Request
{
    public class CreateProveedorDto
    {
        public string DenominacionComercial { get; set; }
        public string RazonSocial { get; set; }
        public string DireccionFisica { get; set; }
        public string TipoDocumentoIdentidad { get; set; }
        public string NumeroDocumentoIdentidad { get; set; }
        public string Estatus { get; set; }
    }
}