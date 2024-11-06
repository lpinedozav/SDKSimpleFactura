using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class SubRecargo
    {
        /// <summary>
        /// Tipo de subdescuento.
        /// </summary>
        public Enum.ExpresionDinero.ExpresionDineroEnum TipoRecargo { get; set; }

        private double _valorRecargo;
        /// <summary>
        /// Valor de subdescuento.
        /// </summary>
        public double ValorRecargo { get { return Math.Round(_valorRecargo, 2); } set { _valorRecargo = value; } }

        public SubRecargo()
        {
            TipoRecargo = Enum.ExpresionDinero.ExpresionDineroEnum.NotSet;
            ValorRecargo = 0;
        }
    }
}
