using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class Comisiones
    {
        /// <summary>
        /// Valor neto comisiones y otros cargos.
        /// Suma de detalle de Valores de Comisiones y Otros Cargos 
        /// </summary>
        public int ValComNeto { get; set; }

        /// <summary>
        /// Valor comisión y otros cargos no afectos o exentos.
        /// Suma de detalles de valores de comisiones y otros cargos no afectos o exentos.
        /// </summary>
        public int ValComExe { get; set; }

        /// <summary>
        /// Valor IVA comisiones y otros cargos
        /// Suma de detalle de IVA de Valor de Comisiones y Otros Cargos.
        /// </summary>
        public int ValComIVA { get; set; }

        public Comisiones()
        {
            ValComNeto = 0;
            ValComExe = 0;
            ValComIVA = 0;
        }
    }
}
