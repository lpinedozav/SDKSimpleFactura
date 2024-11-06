using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class ImpuestosRetenciones
    {
        /// <summary>
        /// Tipo de impuesto o retención adicional.
        /// Código del impuesto o retención de acuerdo a la codificación detallada en tabla de códigos (ver Punto 4 del índice: Codificación Tipos de Impuesto).
        /// Incluye Retención de Cambio sujeto de Construcción.
        /// </summary>
        public Enum.TipoImpuesto.TipoImpuestoEnum TipoImp { get; set; }

        private double _tasaImpuesto;

        /// <summary>
        /// Tasa de impuesto o retención.
        /// Se debe indicar la tasa de Impuesto adicional o retención. 
        /// En el caso de impuesto específicos se puede omitir.
        /// Según las tasas válidas al momento de la transacción.
        /// </summary>
        public double TasaImp { get { return Math.Round(_tasaImpuesto, 2); } set { _tasaImpuesto = value; } }

        /// <summary>
        /// Monto del impuesto o retención.
        /// Valor del impuesto o retención asociado al código indicado anteriormente.
        /// 1.- Tasa * (Suma de líneas de detalle con código de Impuesto adicional o retención), excepto Diesel, Gasolina, margen de comercialización e “Iva anticipado faenamiento carne” .
        /// 2.- Tasa * Monto base faenamiento para IVA anticipado faenamiento carne.
        /// 3.- Valor numérico en otros casos mayor a cero.
        /// </summary>
        public int MontoImp { get; set; }

        public ImpuestosRetenciones()
        {
            TipoImp = Enum.TipoImpuesto.TipoImpuestoEnum.NotSet;
            TasaImp = 0;
            MontoImp = 0;
        }
    }
}
