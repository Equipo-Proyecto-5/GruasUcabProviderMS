namespace ProviderMS.Commons.Dtos.Respose
{
    public class GetProveedorDto
    {
        public Guid Id { get; set; }
        public string DenominacionComercial { get; set; }
        public string RazonSocial { get; set; }
        public string DireccionFisica { get; set; }
        public string TipoDocumentoIdentidad { get; set; }
        public string NumeroDocumentoIdentidad { get; set; }
        public string Estatus { get; set; }
    }
}
