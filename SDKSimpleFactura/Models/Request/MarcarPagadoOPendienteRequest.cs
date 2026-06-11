using SDKSimpleFactura.Models.Facturacion;

namespace SDKSimpleFactura.Models.Request
{
    /// <summary>
    /// Request para marcar un DTE como pagado o pendiente (/dte/marcar-pagado-pendiente)
    /// </summary>
    public class MarcarPagadoOPendienteRequest
    {
        public Credenciales Credenciales { get; set; }
        public DteReferenciadoExterno DteReferenciadoExterno { get; set; }
        public bool Pagado { get; set; }

        public MarcarPagadoOPendienteRequest()
        {
            Credenciales = new Credenciales();
            DteReferenciadoExterno = new DteReferenciadoExterno();
        }
    }
}
