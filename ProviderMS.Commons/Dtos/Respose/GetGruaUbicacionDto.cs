using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderMS.Commons.Dtos.Respose
{
    public class GetGruaUbicacionDto
    {
        public GetGruaUbicacionDto(Guid id,
                        string tipo,
                        string marca,
                        string modelo,
                        string placa,
                        string color,
                        double latitud,
                        double longitud)
        { 
            Id = id;
            Tipo = tipo;
            Marca = marca;
            Modelo = modelo;
            Placa = placa;
            Color = color;
            Latitud = latitud;
            Longitud = longitud;
        }

        public Guid Id { get;  set; }
        public string Tipo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get;  set; }
        public string Placa { get; set; }
        public string Color { get;  set; }
        public double Latitud { get; set; }
        public double Longitud { get;  set; }
    }
}
