using SDKSimpleFactura.Enum;
using System;
using System.Collections.Generic;

namespace SDKSimpleFactura.Models.Request
{
    /// <summary>
    /// Request para emitir una Boleta de Honorarios Electrónica (/bhe/emitir y /bhe/terceros/emitir)
    /// </summary>
    public class BHEmitirRequest
    {
        public string RutEmisor { get; set; }

        public string? Correo { get; set; }
        public TipoRetencionEnum Retencion { get; set; }

        public string FechaEmision { get; set; }

        public BheReceptor Receptor { get; set; }
        public BheEmisor Emisor { get; set; }

        public List<BheDetalle> Detalles { get; set; }
        public long? Folio { get; set; }
        public string? Observacion { get; set; }

        public BHEmitirRequest()
        {
            Retencion = TipoRetencionEnum.Receptor;
            FechaEmision = DateTime.Now.ToString();
            Receptor = new BheReceptor();
            Emisor = new BheEmisor();
            Detalles = new List<BheDetalle>();
            RutEmisor = string.Empty;
            Correo = string.Empty;
            Folio = 0;
            Observacion = string.Empty;
        }
    }

    public class BheEmisor
    {
        public string? Rut { get; set; }
        public int? Direccion { get; set; }
    }

    public class BheReceptor
    {
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Comuna { get; set; }
        public int Region { get; set; }

        public BheReceptor()
        {
            Rut = string.Empty;
            Nombre = string.Empty;
            Direccion = string.Empty;
            Comuna = string.Empty;
        }
    }

    public class BheDetalle
    {
        public string Nombre { get; set; }
        public int Valor { get; set; }

        public BheDetalle()
        {
            Nombre = string.Empty;
        }
    }
}
