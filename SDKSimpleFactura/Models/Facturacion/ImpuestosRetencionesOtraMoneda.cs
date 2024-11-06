using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class ImpuestosRetencionesOtraMoneda
    {
        /// <summary>
        /// Tipo de impuesto o retención adicional.
        /// Código del impuesto o retención de acuerdo a la codificación detallada en tabla de códigos (ver Punto 4 del índice: Codificación Tipos de Impuesto).
        /// Incluye Retención de Cambio sujeto de Construcción.
        /// </summary>
        public Enum.TipoImpuesto.TipoImpuestoEnum TipoImpOtrMnda { get; set; }

        private double _tasaImpuesto;

        /// <summary>
        /// Tasa de impuesto o retención.
        /// Se debe indicar la tasa de Impuesto adicional o retención. 
        /// En el caso de impuesto específicos se puede omitir.
        /// Según las tasas válidas al momento de la transacción.
        /// </summary>
        public double TasaImpOtrMnda { get { return Math.Round(_tasaImpuesto, 2); } set { _tasaImpuesto = value; } }

        private double _montoImpuesto;
        /// <summary>
        /// Monto del impuesto o retención.
        /// Valor del impuesto o retención (en otra moneda) asociado al código indicado anteriormente.
        /// 1.- Tasa * (Suma de líneas de detalle con código de Impuesto adicional o retención), excepto Diesel, Gasolina, margen de comercialización e “Iva anticipado faenamiento carne” .
        /// 2.- Tasa * Monto base faenamiento para IVA anticipado faenamiento carne.
        /// 3.- Valor numérico en otros casos mayor a cero.
        /// </summary>
        public double VlrImpOtrMnda { get { return Math.Round(_montoImpuesto, 4); } set { _montoImpuesto = value; } }

        public ImpuestosRetencionesOtraMoneda()
        {
            TipoImpOtrMnda = Enum.TipoImpuesto.TipoImpuestoEnum.NotSet;
            TasaImpOtrMnda = 0;
            VlrImpOtrMnda = 0;
        }
    }
}
