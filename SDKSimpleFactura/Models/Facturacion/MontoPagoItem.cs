using SDKSimpleFactura.Helpers;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class MontoPagoItem
    {
        /// <summary>
        /// Fecha de pago programado. AAAA-MM-DD
        /// </summary>
        public string FchPago { get; set; }

        /// <summary>
        /// Monto de pago programado.
        /// </summary>
        public int MntPago { get; set; }

        private string _glosa;
        /// <summary>
        /// Glosa adicional para calificar pago
        /// </summary>
        public string GlosaPagos { get { return _glosa.Truncate(40); } set { _glosa = value; } }
    }
}
