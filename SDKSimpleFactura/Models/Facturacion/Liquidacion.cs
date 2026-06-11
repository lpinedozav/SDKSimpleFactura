using System.Collections.Generic;

namespace SDKSimpleFactura.Models.Facturacion
{
    /// <summary>
    /// Liquidación de factura electrónica.
    /// </summary>
    public class Liquidacion
    {
        public string? Id { get; set; }

        /// <summary>
        /// Identificación y totales del documento.
        /// </summary>
        public Encabezado Encabezado { get; set; }

        /// <summary>
        /// Detalle de ítemes del DTE.
        /// Debe ir al menos una línea de detalle. El máximo de ítems es de 60.
        /// </summary>
        public List<DetalleLiquidacion> Detalle { get; set; }

        /// <summary>
        /// Subtotales informativos.
        /// Pueden ser de 0 hasta 20 líneas.
        /// </summary>
        public List<SubTotal>? SubTotInfo { get; set; }

        /// <summary>
        /// Descuentos y/o recargos que afecta al total del documento.
        /// Pueden ser de 0 hasta 20 líneas.
        /// </summary>
        public List<DescuentosRecargos>? DscRcgGlobal { get; set; }

        /// <summary>
        /// Identificación de otros documentos referenciadas por este documento.
        /// Máximo 40.
        /// </summary>
        public List<Referencia>? Referencia { get; set; }

        /// <summary>
        /// Comisiones y otros cargos.
        /// Es obligatoria para liquidaciones de factura. Máximo 20.
        /// </summary>
        public List<ComisionRecargo>? Comisiones { get; set; }

        public Liquidacion()
        {
            Encabezado = new Encabezado();
            Detalle = new List<DetalleLiquidacion>();
            SubTotInfo = null;
            DscRcgGlobal = null;
            Referencia = null;
            Comisiones = null;
        }
    }
}
