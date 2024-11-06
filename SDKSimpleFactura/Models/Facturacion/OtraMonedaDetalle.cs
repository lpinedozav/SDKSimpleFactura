using System.Xml.Serialization;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class OtraMonedaDetalle
    {
        private double _precioUnitario;
        /// <summary>
        /// Precio unitario en otra moneda.
        /// Obligatorio en Guías de Despacho con Indicador de tipo de Traslado de Bienes = 9.
        /// </summary>
        public double PrcOtrMon { get { return Math.Round(_precioUnitario, 4); } set { _precioUnitario = value; } }

        /// <summary>
        /// Código de otra moneda.
        /// (Usar códigos de otra moneda del banco central).
        /// </summary>
        public string Moneda { get; set; }

        private double _factorConversion;
        /// <summary>
        /// Factor para conversión a pesos.
        /// En documentos de Exportación corresponde al tipo de cambio de la fecha de emisión del documento, publicado por el Banco Central de Chile. 
        /// </summary>
        public double FctConv { get { return Math.Round(_factorConversion, 4); } set { _factorConversion = value; } }

        private double _descuento;
        /// <summary>
        /// Descuento en otra moneda.
        /// Dinero correspondiente al Descuento en %. Totaliza todos los descuentos otorgados al ítem en otra moneda.
        /// </summary>
        public double DctoOtrMnda { get { return Math.Round(_descuento, 4); } set { _descuento = value; } }

        private double _recargo;
        /// <summary>
        /// Recargo en otra moneda.
        /// Dinero correspondiente al Recargo en %. Totaliza todos los recargos otorgados al ítem en otra moneda.
        /// </summary>
        public double RecargoOtrMnda { get { return Math.Round(_recargo, 4); } set { _recargo = value; } }

        private double _valor;
        /// <summary>
        /// Valor por línea de detalle en otra moneda.
        /// (Precio Unitario en otra moneda * Cantidad ) – Descuento en otra moneda + Recargo en otra moneda.
        /// Obligatorio en Guías de Despacho con Indicador de tipo de Traslado de Bienes = 9.
        /// </summary>
        public double MontoItemOtrMnda { get { return Math.Round(_valor, 4); } set { _valor = value; } }

        public OtraMonedaDetalle()
        {
            PrcOtrMon = 0;
            Moneda = string.Empty;
            FctConv = 0;
            DctoOtrMnda = 0;
            RecargoOtrMnda = 0;
            MontoItemOtrMnda = 0;
        }
    }
}
