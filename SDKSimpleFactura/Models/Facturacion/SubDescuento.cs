using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class SubDescuento
    {
        /// <summary>
        /// Indica en qué está expresado el descuento, en porcentaje (%) o pesos ($).
        /// </summary>
        public Enum.ExpresionDinero.ExpresionDineroEnum TipoDscto { get; set; }

        private double _valorDescuento;
        /// <summary>
        /// Valor de subdescuento.
        /// </summary>
        public double ValorDscto { get { return Math.Round(_valorDescuento, 2); } set { _valorDescuento = value; } }

        public SubDescuento()
        {
            TipoDscto = Enum.ExpresionDinero.ExpresionDineroEnum.NotSet;
            ValorDscto = 0;
        }
    }
}
