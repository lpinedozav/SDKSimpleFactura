using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKSimpleFactura.Models.Response
{
    public class InvoiceData
    {
        public int TipoDTE { get; set; }
        public string RUTEmisor { get; set; }
        public string RUTReceptor { get; set; }
        public long Folio { get; set; }
        public string FechaEmision { get; set; }
        public double Total { get; set; }
    }
}
