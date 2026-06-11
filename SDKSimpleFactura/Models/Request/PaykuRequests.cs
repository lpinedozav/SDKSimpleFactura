using SDKSimpleFactura.Models.Facturacion;
using System;

namespace SDKSimpleFactura.Models.Request
{
    /// <summary>
    /// Request para listar transacciones Payku (/payku/transacciones)
    /// </summary>
    public class PaykuTransaccionesRequest
    {
        public Credenciales Credenciales { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }

        public PaykuTransaccionesRequest()
        {
            Credenciales = new Credenciales();
        }
    }

    /// <summary>
    /// Request para activar o desactivar Payku (/payku/activar-desactivar)
    /// </summary>
    public class PaykuToggleRequest
    {
        public Credenciales Credenciales { get; set; }
        public bool Activo { get; set; }

        public PaykuToggleRequest()
        {
            Credenciales = new Credenciales();
        }
    }

    /// <summary>
    /// Request para generar URL o reenviar link de pago Payku (/payku/generar-url y /payku/reenviar-link-Qr)
    /// </summary>
    public class PaykuReenviarLinkRequest
    {
        public Credenciales Credenciales { get; set; }
        public DteReferenciadoExterno Dte { get; set; }

        public PaykuReenviarLinkRequest()
        {
            Credenciales = new Credenciales();
            Dte = new DteReferenciadoExterno();
        }
    }
}
