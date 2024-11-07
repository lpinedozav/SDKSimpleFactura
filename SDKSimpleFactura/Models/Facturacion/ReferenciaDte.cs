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
        public string Fecha { get; set; }
        public DateTime FchRef { get { return DateTime.Parse(Fecha); } set { Fecha = value.ToString("yyyy-MM-dd"); } }
        public string Motivo { get; set; }
        public string Razon { get; set; }
        public string Glosa { get; set; }
        public int Folio { get; set; }
        public Enum.TipoDTE.DTEType TipoDoc {  get; set; }

    }
}
