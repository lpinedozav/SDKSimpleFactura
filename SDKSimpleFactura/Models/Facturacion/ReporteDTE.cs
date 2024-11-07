using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class ReporteDTE
    {
        public DateTime Fecha { get; set; }
        public string TiposDTE { get; set; }
        public int Emitidos { get; set; }
        public int Anulados { get; set; }
        public decimal TotalNeto { get; set; }
        public decimal TotalExento { get; set; }
        public decimal TotalIva { get; set; }
        public decimal Total { get; set; }
        public List<DetalleDte> Detalle { get; set; }
    }

}
