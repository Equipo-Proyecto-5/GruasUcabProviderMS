using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderMS.Domain.Entities
{
    public class Proveedor
    {
        public Guid Id { get; private set; }
        public string DenominacionComercial { get; private set; }
        public string RazonSocial { get; private set; }

        public string DireccionFisica { get; private set; }

        public string TipoDocumentoIdentidad { get; private set; }
        public string NumeroDocumentoIdentidad { get; private set; }
        public string Estatus { get; private set; }

        public Proveedor(Guid id, string denominacionComercial, string razonSocial, string direccionFisica, string tipoDocumentoIdentidad, string numeroDocumentoIdentidad, string estatus)
        {
            Id = id;
            DenominacionComercial = denominacionComercial;
            RazonSocial = razonSocial;
            DireccionFisica = direccionFisica;
            TipoDocumentoIdentidad = tipoDocumentoIdentidad;
            NumeroDocumentoIdentidad = numeroDocumentoIdentidad;
            Estatus = estatus;
        }

    }
}
