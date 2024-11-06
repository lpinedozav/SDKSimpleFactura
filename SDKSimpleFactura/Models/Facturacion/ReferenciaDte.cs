using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class ReferenciaDte
    {
        // Por ejemplo:
        public int Folio { get; set; }
        public string TipoDocumento { get; set; }
        public string RazonReferencia { get; set; }
        public string FechaDocumentoReferencia { get; set; } // Considera usar DateTime
    }
}
