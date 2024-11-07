using SDKSimpleFactura.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SDKSimpleFactura.Enum.Ambiente;
using static SDKSimpleFactura.Enum.TipoDTE;
using static SDKSimpleFactura.Enum.TipoSalida;


namespace SDKSimpleFactura.Models.Facturacion
{
    public class ListaDteRequest
    {
        public Credenciales Credenciales { get; set; }

        public AmbienteEnum Ambiente { get; set; }
        public long? Folio { get; set; }
        public DTEType? CodigoTipoDte { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }
        public TipoSalida Salida { get; set; }
        public string? RutEmisor { get; set; }
    }
}
