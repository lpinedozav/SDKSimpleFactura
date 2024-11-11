using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKSimpleFactura.Models.Folios
{
    public class SolicitudFoliosRequest
    {
        public string RutEmpresa { get; set; }
        public int TipoDTE { get; set; }
        public int? Ambiente { get; set; }
    }
}
