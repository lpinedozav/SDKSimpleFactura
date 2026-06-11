using System;

namespace SDKSimpleFactura.Models.Response
{
    /// <summary>
    /// Información de un contribuyente del SII (/contribuyentes/correo-intercambio/{rut})
    /// </summary>
    public class ContribuyenteSiiEnt
    {
        public string Rut { get; set; }
        public string RazonSocial { get; set; }
        public string CorreoIntercambio { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public ContribuyenteSiiEnt()
        {
            Rut = string.Empty;
            RazonSocial = string.Empty;
            CorreoIntercambio = string.Empty;
        }
    }
}
