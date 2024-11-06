using SDKSimpleFactura.Helpers;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class ComisionRecargo
    {
        /// <summary>
        /// Número secuencial de la linea.
        /// La obligatoriedad se refiere a que si se incluye esta zona debe haber al menos una línea y este caso debe ir el dato de número de línea. 
        /// </summary>
        public int NroLinCom { get; set; }

        /// <summary>
        /// C (Comisión) u O (Otros cargos).
        /// </summary>
        public Enum.TipoRecargoComision.TipoRecargoComisionEnum TipoMovim { get; set; }

        private string _glosa;
        /// <summary>
        /// Especificación de la comisión u otro cargo.
        /// </summary>
        public string Glosa { get { return _glosa.Truncate(60); } set { _glosa = value; } }

        private double _tasa;

        /// <summary>
        /// Valor porcentual de la comisión u otro cargo.
        /// </summary>
        public double TasaComision { get { return Math.Round(_tasa, 2); } set { _tasa = value; } }

        /// <summary>
        /// Valor neto de la comisión u otro cargo.
        /// En Notas de Crédito, Notas de Débito y Facturas de Compra.
        /// Puede ser cero si el Valor Exento es distinto de cero.
        /// En Liquidaciones-Factura puede ser negativo
        /// </summary>
        public int ValComNeto { get; set; }

        /// <summary>
        /// Valor no afecto o exento de la comisión u otros cargos.
        /// En Notas de Crédito, Notas de Débito y Facturas de Compra.
        /// Puede ser cero si el Valor Neto es distinto de cero.
        /// En Liquidaciones-Factura puede ser negativo
        /// </summary>
        public int ValComExe { get; set; }

        /// <summary>
        /// Valor IVA de la comisión u otros cargos.
        /// Valor * Tasa IVA.
        /// En Notas de Crédito, Notas de Débito y Facturas de Compra.
        /// En Liquidaciones-Factura puede ser negativo.
        /// </summary>
        public int ValComIVA { get; set; }

        public ComisionRecargo()
        {
            NroLinCom = 0;
            TipoMovim = Enum.TipoRecargoComision.TipoRecargoComisionEnum.NotSet;
            Glosa = string.Empty;
            ValComNeto = 0;
            ValComExe = 0;

            TasaComision = 0;
            ValComIVA = 0;
        }
    }
}
