using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class Dte
    {
        public string Ambiente { get; set; }
        public string FolioReutilizado { get; set; }
        public string Importado { get; set; }
        public int CodigoSii { get; set; }
        public string TipoDte { get; set; }
        public string EstadoAcuse { get; set; }
        public string EstadoSII { get; set; }
        public string FechaDte { get; set; } // Considera usar DateTime si es adecuado
        public string FechaCreacion { get; set; } // Considera usar DateTime
        public int Folio { get; set; }
        public string RazonSocialReceptor { get; set; }
        public string RutReceptor { get; set; }
        public long TrackId { get; set; }
        public decimal Neto { get; set; }
        public decimal Exento { get; set; }
        public decimal Iva { get; set; }
        public decimal IvaTerceros { get; set; }
        public decimal IvaPropio { get; set; }
        public decimal TotalImpuestosAdicionales { get; set; }
        public decimal Total { get; set; }
        public List<DetalleDte> Detalles { get; set; }
        public List<ReferenciaDte> Referencias { get; set; }
    }
}
