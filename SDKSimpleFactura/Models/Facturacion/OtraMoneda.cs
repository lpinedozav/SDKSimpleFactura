using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class OtraMoneda
    {
        /// <summary>
        /// Tipo tra moneda.
        /// Tabla de monedas de aduana.
        /// Moneda alternativa en que se expresan los montos totales.
        /// </summary>
        public Enum.CodigosAduana.Moneda TpoMoneda { get; set; }

        private double _tipoCambio;
        /// <summary>
        /// Tipo de cambio fijado por el Banco Central de Chile.
        /// 1. Factor de conversión utilizado de pesos a Otra moneda 
        /// 2. 6 enteros y 4 decimales 
        /// 3. En documentos de Exportación corresponde al tipo de cambio de la fecha de emisión del documento, publicado por el Banco Central de Chile. 
        /// </summary>
        public double TpoCambio { get { return Math.Round(_tipoCambio, 4); } set { _tipoCambio = value; } }

        private double _montoNeto;
        /// <summary>
        /// Monto neto del DTE en otra moneda.
        /// Suma de valores total de ítems afectos en Otra Moneda - descuentos globales en Otra Moneda + recargos globales en Otra Moneda (Asignados a ítems afectos en Otra Moneda).
        /// Si está encendido el Indicador de Montos Brutos (=1) entonces el resultado anterior se debe dividir por (1 + tasa de IVA)
        /// </summary>
        public double MntNetoOtrMnda { get { return Math.Round(_montoNeto, 4); } set { _montoNeto = value; } }

        private double _montoExento;
        /// <summary>
        /// Monto exento del DTE en otra moneda.
        /// Suma de valores total de ítems no afectos o exentos en Otra Moneda - descuentos globales en Otra Moneda + recargos globales en Otra Moneda (Asignados a ítems exentos o no afectos en Otra Moneda)
        /// </summary>
        public double MntExeOtrMnda { get { return Math.Round(_montoExento, 4); } set { _montoExento = value; } }

        private double _montoBaseFaenamientoCarne;
        /// <summary>
        /// Monto base faenamiento carne en otra moneda.
        /// Monto informado.
        /// </summary>
        public double MntFaeCarneOtrMnda { get { return Math.Round(_montoBaseFaenamientoCarne, 4); } set { _montoBaseFaenamientoCarne = value; } }

        private double _montoBaseMargenComercial;
        /// <summary>
        /// Monto base de márgenes de comercialización. 
        /// Monto informado.
        /// </summary>
        public double MntMargComOtrMnda { get { return Math.Round(_montoBaseMargenComercial, 4); } set { _montoBaseMargenComercial = value; } }

        private double _IVA;
        /// <summary>
        /// Monto del IVA del DTE en otra moneda.
        /// </summary>
        public double IVAOtrMnda { get { return Math.Round(_IVA, 4); } set { _IVA = value; } }

        /// <summary>
        /// Impuestos y retenciones adicionales.
        /// </summary>
        public List<ImpuestosRetencionesOtraMoneda>? ImpRetOtrMnda { get; set; }

        private double _IVANoRetenido;
        /// <summary>
        /// Monto del IVA no retenido en otra moneda.
        /// </summary>
        public double IVANoRetOtrMnda { get { return Math.Round(_IVANoRetenido, 4); } set { _IVANoRetenido = value; } }

        private double _montoTotal;
        /// <summary>
        /// Monto total del DTE en otra moneda.
        /// </summary>
        public double MntTotOtrMnda { get { return Math.Round(_montoTotal, 4); } set { _montoTotal = value; } }
        public OtraMoneda()
        {
            TpoMoneda = Enum.CodigosAduana.Moneda.NotSet;
            MntTotOtrMnda = 0;
            TpoCambio = 0;
            MntNetoOtrMnda = 0;
            MntExeOtrMnda = 0;
            MntFaeCarneOtrMnda = 0;
            MntMargComOtrMnda = 0;
            IVAOtrMnda = 0;
            ImpRetOtrMnda = null;
            IVANoRetOtrMnda = 0;
        }
    }
}
