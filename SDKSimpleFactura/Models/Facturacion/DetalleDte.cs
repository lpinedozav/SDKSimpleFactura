using SDKSimpleFactura.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class DetalleDte
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Exento { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? TotalImpuestos { get; set; }
        public decimal? Total { get; set; }
        public DateTime? Fecha { get; set; }
        public TipoDTE.DTEType? CodigoSii { get; set; }
        public string? TipoDTE { get; set; }
        public int? CantidadEmitidos { get; set; }
        public int? CantidadAnulados { get; set; }
        public decimal? TotalNeto { get; set; }
        public decimal? TotalExento { get; set; }
        public decimal? TotalIva { get; set; }

    }
}
