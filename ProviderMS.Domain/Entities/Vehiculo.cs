

namespace ProviderMS.Domain.Entities
{
    public class Vehiculo
    {

        public Guid Id { get; set; }

        public string  Marca { get; set; }

        public string Modelo { get; set; }

        public string Año { get; set; }

        public string Placa { get; set; }

        public string Color { get; set; }

        public string Estatus { get; set; }

        public string? Localizacion { get; set; }

        public string? Longitud { get; set; }

        public string? Latitud { get; set; }

        public string? Hora { get; set; }

    }
}
