using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class Encabezado
    {
        /// <summary>
        /// Identificación y totales del documento.
        /// </summary>
        public IdentificacionDTE IdDoc { get; set; }

        /// <summary>
        /// Datos del emisor
        /// </summary>
        public Emisor Emisor { get; set; }

        /// <summary>
        /// Rut a cuenta de quien se emite el DTE.
        /// Corresponde al RUT del mandante si el total de la venta o servicio es por cuenta de otro el cual es responsable del IVA devengado en el período.
        /// Con guión y dígito verificador 
        /// </summary>
        public string? RUTMandante { get; set; }

        /// <summary>
        /// Datos del receptor
        /// </summary>
        public Receptor Receptor { get; set; }

        /// <summary>
        /// Rut que solicita el DTE en venta a público.
        /// En casos de venta a público. Es obligatorio si es distinto de Rut receptor o Rut Receptor es persona jurídica. 
        /// Con guión y dígito verificador 
        /// </summary>
        public string? RUTSolicita { get; set; }

        /// <summary>
        /// Información de transporte de mercaderías.
        /// </summary>
        public Transporte? Transporte { get; set; }

        /// <summary>
        /// Montos totales del DTE
        /// </summary>
        public Totales Totales { get; set; }

        /// <summary>
        /// Otra moneda.
        /// </summary>
        public OtraMoneda? OtraMoneda { get; set; }

        public Encabezado()
        {
            RUTMandante = string.Empty;
            RUTSolicita = string.Empty;
            IdDoc = new IdentificacionDTE();
            Emisor = new Emisor();
            Receptor = new Receptor();
            Transporte = null;
            Totales = new Totales();
            OtraMoneda = new OtraMoneda();
        }
    }
}
