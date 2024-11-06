using SDKSimpleFactura.Helpers;
using System.Xml.Serialization;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class Detalle
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
        /// Indicador de exención/facturación.
        /// Indica si el producto o servicio es exento o no afecto a impuesto o si ya ha sido facturado. (También se utiliza para indicar garantía de depósito por envases. 
        /// Art.28,Inc3 Reglamento DL 825) (Cervezas, Jugos, Aguas Minerales, Bebidas Analcohólicas u otros autorizados por Resolución especial).
        /// Si todos los ítems de una factura tienen valor 1 en este indicador la factura no puede ser factura electrónica (código 33), debería ser factura exenta (código 34).
        /// Sólo en caso de Liquidación-Factura que tenga ítems no facturables negativos, se debe señalar el indicador 2, e informar el valor con signo negativo
        /// </summary>
        public Enum.IndicadorFacturacionExencionEnum IndExe { get; set; }

        /// <summary>
        /// Sólo para transacciones realizadas por agentes retenedores. No aplica para facturas de exportación
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
        /// Descripción Adicional del producto o servicio. Se utiliza para pack, servicios con detalle.
        /// </summary>
        public string? DscItem { get { return _descripcion.Truncate(1000); } set { _descripcion = value; } }

        private double _cantidadUnidadMedidaReferencia;
        /// <summary>
        /// Cantidad para la unidad de medida de referencia.
        /// No se usa para el cálculo del valor neto.
        /// Obligatorio para facturas de venta o compra que indican emisor opera como Agente Retenedor.
        /// En Guías de Despacho, y en Indicador de tipo de transporte 8 o 9, es obligatoria si el campo Cantidad no está en la unidad Kgs brutos.
        /// </summary>
        public double QtyRef { get { return Math.Round(_cantidadUnidadMedidaReferencia, 6); } set { _cantidadUnidadMedidaReferencia = value; } }

        private string _unidadMedidaReferencia;
        /// <summary>
        /// Unidad de medida de referencia.
        /// Glosa con unidad de medida de referencia Obligatorio para facturas de venta, compra o notas que indican emisor opera como Agente Retenedor.
        /// En Guías de Despacho con Indicador de tipo de Traslado de Bienes 8 o 9, es obligatoria si el campo Cantidad no está en la unidad Kgs brutos. 
        /// Adicionalmente en dicho caso se debe utilizar tabla de unidades de Aduanas.
        /// </summary>
        public string UnmdRef { get { return _unidadMedidaReferencia.Truncate(4); } set { _unidadMedidaReferencia = value; } }

        private double _precioUnitarioUnidadMedidaReferencia;
        /// <summary>
        /// Precio unitario de referencia para unidad de medida de referencia.
        /// No se usa para el cálculo del valor neto.
        /// Obligatorio para facturas de venta, compra o notas que indican emisor opera como Agente Retenedor.
        /// </summary>
        public double PrcRef { get { return Math.Round(_precioUnitarioUnidadMedidaReferencia, 6); } set { _precioUnitarioUnidadMedidaReferencia = value; } }

        private double _cantidad;

        /// <summary>
        /// Cantidad del ítem.
        /// Obligatorio para facturas de venta, compra o notas que indican emisor opera como Agente Retenedor
        /// </summary>
        public double QtyItem { get { return Math.Round(_cantidad, 6); } set { _cantidad = value; } }

        /// <summary>
        /// Distribución de la cantidad.
        /// </summary>
        public List<SubCantidad>? Subcantidad { get; set; }

        /// <summary>
        /// Fecha de elaboración del item. (AAAA-MM-DD).
        /// Do not set this property, set FechaElaboracion instead.
        /// </summary>
        public string FechaElaboracionString { get; set; }
        public bool ShouldSerializeFechaElaboracionString() { return FchElabor != DateTime.MinValue; }
        /// <summary>
        /// Fecha de elaboracion del item. (AAAA-MM-DD)
        /// </summary>
        public DateTime FchElabor { get { return DateTime.Parse(FechaElaboracionString); } set { FechaElaboracionString = value.ToString("yyyy-MM-dd"); } }

        /// <summary>
        /// Fecha de vencimiento del item. (AAAA-MM-DD).
        /// Do not set this property, set FechaVencimiento instead.
        /// </summary>
        public string FechaVencimientoString { get; set; }

        /// <summary>
        /// Fecha de vencimiento del item. (AAAA-MM-DD).
        /// </summary>
        public DateTime FchVencim { get { return DateTime.Parse(FechaVencimientoString); } set { FechaVencimientoString = value.ToString("yyyy-MM-dd"); } }

        private string _unidadMedida;
        /// <summary>
        /// Unidad de medida.
        /// Obligatorio para facturas de venta, compra o notas que indican emisor opera como Agente Retenedor.
        /// Obligatorio en Guías de Despacho con Indicador de tipo de Traslado de Bienes = 8 y 9.
        /// En Facturas de Exportación Campo obligatorio a excepción cuando en el “Indicador de Servicio” se registra el valor 3, 4 o 5. 
        /// En dicho caso se debe utilizar tabla de unidades de Aduanas.
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
        /// Codigo de impuesto adicional o retención. No aplica para facturas de exportación.
        /// Indica el código según tabla de códigos (Ver en Índice 4.- Codificación Tipos de Impuesto). 
        /// </summary>
        public List<Enum.TipoImpuesto.TipoImpuestoEnum>? CodImpAdic { get; set; }

        /// <summary>
        /// Monto por línea de detalle, corresponde al monto neto, a menos que sea MntBruto indique lo contrario.
        /// (Precio Unitario * Cantidad ) – Monto Descuento + Monto Recargo.
        /// Valor numérico, de acuerdo con descripción y:
        /// 1) Debe ser cero cuando:
        ///  - Indicador de facturación/ exención tiene valor 4 o 5.
        ///  - Es una Nota de Crédito tipo fe de erratas.(Ver campo Código de Referencia en Referencias).
        /// 2) Puede ser cero cuando el documento es una Guía de despacho NO VENTA (Según campo Indicador Tipo de traslado de bienes del encabezado).
        /// 3) En liquidaciones factura puede ser negativo.
        /// CUANDO ES CERO PUEDE NO IMPRIMIRSE o Imprimirse un texto explicatorio (s/valor, sin costo, etc).
        /// </summary>
        public int MontoItem { get; set; }

        public Detalle()
        {
            NroLinDet = 0;
            NmbItem = string.Empty;
            MontoItem = 0;
            CdgItem = null;
            IndExe = Enum.IndicadorFacturacionExencionEnum.NotSet;
            Retenedor = null;
            DscItem = string.Empty; ;
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
