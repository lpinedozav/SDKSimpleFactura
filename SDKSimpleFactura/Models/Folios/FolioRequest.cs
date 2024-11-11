using SDKSimpleFactura.Models.Facturacion;
using static SDKSimpleFactura.Enum.TipoDTE;

namespace SDKSimpleFactura.Models.Folios
{
    public class FolioRequest
    {
        public Credenciales Credenciales { get; set; }
        public int Cantidad { get; set; }
        public DTEType? CodigoTipoDte { get; set; }
        public int? Ambiente { get; set; }
    }
}
