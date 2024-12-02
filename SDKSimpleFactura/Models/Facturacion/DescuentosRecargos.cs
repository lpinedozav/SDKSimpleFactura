using SDKSimpleFactura.Helpers;
using System;
namespace SDKSimpleFactura.Models.Facturacion
{
    public class DescuentosRecargos
    {
        /// <summary>
        /// Número secuencial de línea.
        /// La obligatoriedad se refiere a que si se incluye esta zona debe haber al menos una línea y este caso debe ir el dato de número de línea. 
        /// </summary>
        public int NroLinDR { get; set; }

        /// <summary>
        /// Tipo de movimiento.
        /// </summary>
        public Enum.TipoMovimiento.TipoMovimientoEnum TpoMov { get; set; }

        private string _glosa;
        /// <summary>
        /// Descripción del descuento o recargo.
        /// </summary>
        public string GlosaDR { get { return _glosa.Truncate(45); } set { _glosa = value; } }

        /// <summary>
        /// Unidad en que se expresa el valor.
        /// </summary>
        public Enum.ExpresionDinero.ExpresionDineroEnum TpoValor { get; set; }

        private double _valor;
        /// <summary>
        /// Valor del descuento o recargo
        /// </summary>
        public double ValorDR { get { return Math.Round(_valor, 2); } set { _valor = value; } }

        private double _valorOtraMoneda;
        /// <summary>
        /// Valor en otra moneda
        /// </summary>
        public double ValorDROtrMnda { get { return Math.Round(_valorOtraMoneda, 4); } set { _valorOtraMoneda = value; } }

        /// <summary>
        /// Indica si el descuento o recargo es No afecto o no facturable.
        /// </summary>
        public Enum.IndicadorExento.IndicadorExentoEnum IndExeDR { get; set; }
        public bool ShouldSerializeIndicadorExento() { return IndExeDR != Enum.IndicadorExento.IndicadorExentoEnum.NotSet; }

        public DescuentosRecargos()
        {
            NroLinDR = 0;
            TpoMov = Enum.TipoMovimiento.TipoMovimientoEnum.NotSet;
            GlosaDR = string.Empty;
            TpoValor = Enum.ExpresionDinero.ExpresionDineroEnum.NotSet;
            ValorDR = 0;
            ValorDROtrMnda = 0;
            IndExeDR = Enum.IndicadorExento.IndicadorExentoEnum.NotSet;
        }
    }
}
