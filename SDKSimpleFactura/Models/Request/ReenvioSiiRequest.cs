using SDKSimpleFactura.Models.Facturacion;
using static SDKSimpleFactura.Enum.Ambiente;
using static SDKSimpleFactura.Enum.TipoDTE;

namespace SDKSimpleFactura.Models.Request
{
    /// <summary>
    /// Request para reenviar un DTE al SII (/dte/reenviar-sii)
    /// </summary>
    public class ReenvioSiiRequest
    {
        public Credenciales Credenciales { get; set; }
        public long Folio { get; set; }
        public DTEType CodigoTipoDte { get; set; }
        public AmbienteEnum Ambiente { get; set; }

        public ReenvioSiiRequest()
        {
            Credenciales = new Credenciales();
        }
    }
}
