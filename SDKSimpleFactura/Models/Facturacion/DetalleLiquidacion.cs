using SDKSimpleFactura.Helpers;
using System;
using System.Collections.Generic;

namespace SDKSimpleFactura.Models.Facturacion
{
    /// <summary>
    /// Línea de detalle de una liquidación de factura.
    /// </summary>
    public class DetalleLiquidacion
    {
        /// <summary>
        /// Número secuencial de línea.
        /// De 1 a 60.
        /// </summary>
        public int NroLinDet { get; set; }

        /// <summary>
        /// Codificación del item.
        /// Se pueden incluir 5 repeticiones de pares código-valor.
        /// </summary>
        public List<CodigoItem>? CdgItem { get; set; }

        /// <summary>
        /// Codigo del tipo de documento que se liquida.
        /// Indica el código según tabla de códigos (Codificación Tipos de DTE).
        /// </summary>
        public string TpoDocLiq { get; set; }

        /// <summary>
        /// Indicador de exención/facturación.
        /// </summary>
        public Enum.IndicadorFacturacionExencionEnum IndExe { get; set; }

        /// <summary>
        /// Sólo para transacciones realizadas por agentes retenedores.
        /// </summary>
        public Retenedor? Retenedor { get; set; }

        private string _nombre;
        /// <summary>
        /// Nombre del producto o servicio.
        /// </summary>
        public string NmbItem { get { return _nombre.Truncate(80); } set { _nombre = value; } }

        private string _descripcion;
        /// <summary>
        /// Descripción del item.
        /// </summary>
        public string? DscItem { get { return _descripcion.Truncate(1000); } set { _descripcion = value; } }

        private double _cantidadUnidadMedidaReferencia;
        /// <summary>
        /// Cantidad para la unidad de medida de referencia.
        /// </summary>
        public double QtyRef { get { return Math.Round(_cantidadUnidadMedidaReferencia, 6); } set { _cantidadUnidadMedidaReferencia = value; } }

        private string _unidadMedidaReferencia;
        /// <summary>
        /// Unidad de medida de referencia.
        /// </summary>
        public string UnmdRef { get { return _unidadMedidaReferencia.Truncate(4); } set { _unidadMedidaReferencia = value; } }

        private double _precioUnitarioUnidadMedidaReferencia;
        /// <summary>
        /// Precio unitario de referencia para unidad de medida de referencia.
        /// </summary>
        public double PrcRef { get { return Math.Round(_precioUnitarioUnidadMedidaReferencia, 6); } set { _precioUnitarioUnidadMedidaReferencia = value; } }

        private double _cantidad;
        /// <summary>
        /// Cantidad del ítem.
        /// </summary>
        public double QtyItem { get { return Math.Round(_cantidad, 6); } set { _cantidad = value; } }

        /// <summary>
        /// Distribución de la cantidad.
        /// </summary>
        public List<SubCantidad>? Subcantidad { get; set; }

        /// <summary>
        /// Fecha de elaboración del item. (AAAA-MM-DD).
        /// Do not set this property, set FchElabor instead.
        /// </summary>
        public string FechaElaboracionString { get; set; }
        public bool ShouldSerializeFechaElaboracionString() { return FchElabor != DateTime.MinValue; }
        /// <summary>
        /// Fecha de elaboracion del item. (AAAA-MM-DD)
        /// </summary>
        public DateTime FchElabor { get { return DateTime.Parse(FechaElaboracionString); } set { FechaElaboracionString = value.ToString("yyyy-MM-dd"); } }

        /// <summary>
        /// Fecha de vencimiento del item. (AAAA-MM-DD).
        /// Do not set this property, set FchVencim instead.
        /// </summary>
        public string FechaVencimientoString { get; set; }

        /// <summary>
        /// Fecha de vencimiento del item. (AAAA-MM-DD).
        /// </summary>
        public DateTime FchVencim { get { return DateTime.Parse(FechaVencimientoString); } set { FechaVencimientoString = value.ToString("yyyy-MM-dd"); } }

        private string _unidadMedida;
        /// <summary>
        /// Unidad de medida.
        /// </summary>
        public string UnmdItem { get { return _unidadMedida.Truncate(4); } set { _unidadMedida = value; } }

        private double _precio;
        /// <summary>
        /// Precio unitario del item en pesos.
        /// </summary>
        public double PrcItem { get { return _precio; } set { _precio = value; } }

        /// <summary>
        /// Precio del item en otra moneda.
        /// </summary>
        public OtraMonedaDetalle? OtrMnda { get; set; }

        private double _descuentoPorcentaje;
        /// <summary>
        /// Porcentaje de descuento.
        /// </summary>
        public double DescuentoPct { get { return Math.Round(_descuentoPorcentaje, 2); } set { _descuentoPorcentaje = value; } }

        /// <summary>
        /// Monto del descuento.
        /// </summary>
        public int DescuentoMonto { get; set; }

        /// <summary>
        /// Desglose del descuento.
        /// Máximo 5 ítemes de subdescuento.
        /// </summary>
        public List<SubDescuento>? SubDscto { get; set; }

        private double _recargoPorcentaje;
        /// <summary>
        /// Porcentaje de recargo.
        /// </summary>
        public double RecargoPct { get { return Math.Round(_recargoPorcentaje, 2); } set { _recargoPorcentaje = value; } }

        /// <summary>
        /// Monto de recargo.
        /// </summary>
        public int RecargoMonto { get; set; }

        /// <summary>
        /// Desglose del recargo.
        /// Máximo 5 ítemes de subrecargo.
        /// </summary>
        public List<SubRecargo>? SubRecargo { get; set; }

        /// <summary>
        /// Codigo de impuesto adicional o retención.
        /// </summary>
        public List<Enum.TipoImpuesto.TipoImpuestoEnum>? CodImpAdic { get; set; }

        /// <summary>
        /// Monto por línea de detalle, corresponde al monto neto, a menos que MntBruto indique lo contrario.
        /// En liquidaciones factura puede ser negativo.
        /// </summary>
        public int MontoItem { get; set; }

        public DetalleLiquidacion()
        {
            NroLinDet = 0;
            NmbItem = string.Empty;
            TpoDocLiq = string.Empty;
            MontoItem = 0;
            CdgItem = null;
            IndExe = Enum.IndicadorFacturacionExencionEnum.NotSet;
            Retenedor = null;
            DscItem = string.Empty;
            QtyRef = 0;
            UnmdRef = string.Empty;
            PrcRef = 0;
            QtyItem = 0;
            Subcantidad = null;
            FchElabor = DateTime.MinValue;
            FchVencim = DateTime.MinValue;
            UnmdItem = string.Empty;
            PrcItem = 0;
            OtrMnda = null;
            DescuentoPct = 0;
            DescuentoMonto = 0;
            SubDscto = null;
            RecargoPct = 0;
            RecargoMonto = 0;
            SubRecargo = null;
            CodImpAdic = null;
        }
    }
}
