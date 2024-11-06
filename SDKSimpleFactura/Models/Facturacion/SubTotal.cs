using SDKSimpleFactura.Helpers;
using System.Xml.Serialization;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class SubTotal
    {
        /// <summary>
        /// Número de sub-total.
        /// Número secuencial de acuerdo al número de subtotales.
        /// </summary>
        public int NroSTI { get; set; }

        private string _glosa;
        /// <summary>
        /// Glosa.
        /// Título del subtotal.
        /// </summary>
        public string GlosaSTI { get { return _glosa.Truncate(40); } set { _glosa = value; } }

        /// <summary>
        /// Ubicación para impresión.
        /// De uso para el contribuyente como ayuda para indicar cómo se imprimirá los subtotales.
        /// </summary>
        public int OrdenSTI { get; set; }

        private double _neto;
        /// <summary>
        /// Valor neto del subtotal.
        /// </summary>
        public double SubTotNetoSTI { get { return Math.Round(_neto, 2); } set { _neto = value; } }

        private double _iva;
        /// <summary>
        /// Valor del IVA del subtotal.
        /// </summary>
        public double SubTotIVASTI { get { return Math.Round(_iva, 2); } set { _iva = value; } }

        private double _impuestoAdicional;
        /// <summary>
        /// Valor de los impuestos adicionales o específicos del subtotal.
        /// </summary>
        public double SubTotAdicSTI { get { return Math.Round(_impuestoAdicional, 2); } set { _impuestoAdicional = value; } }

        private double _montoExento;
        /// <summary>
        /// Valor no afecto o exento del subtotal.
        /// </summary>
        public double SubTotExeSTI { get { return Math.Round(_montoExento, 2); } set { _montoExento = value; } }

        private double _total;
        /// <summary>
        /// Valor de la línea de subtotal.
        /// </summary>
        public double ValSubtotSTI { get { return Math.Round(_total, 2); } set { _total = value; } }

        /// <summary>
        /// tabla de líneas de detalle que se agrupan en el subtotal.
        /// </summary>
        public List<int> LineasDeta { get; set; }

        public SubTotal()
        {
            NroSTI = 0;
            GlosaSTI = string.Empty;
            OrdenSTI = 0;
            SubTotNetoSTI = 0;
            SubTotIVASTI = 0;
            SubTotAdicSTI = 0;
            SubTotExeSTI = 0;
            ValSubtotSTI = 0;
            LineasDeta = null;
        }
    }
}
