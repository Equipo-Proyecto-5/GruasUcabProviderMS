using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderMS.Commons.Dtos.Request.Grua
{
    public class ModifyGruaDto
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Año { get; set; }
        public string Placa { get; set; }
        public string Color { get; set; }


    }
}
