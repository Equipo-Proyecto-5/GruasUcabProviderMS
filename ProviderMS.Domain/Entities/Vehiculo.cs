

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

        public double? Longitud { get; set; }

        public double? Latitud { get; set; }

        public DateTime? Hora { get; set; }

    }
}
