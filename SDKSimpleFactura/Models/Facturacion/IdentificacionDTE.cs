using SDKSimpleFactura.Helpers;
using System.Xml.Serialization;

namespace SDKSimpleFactura.Models.Facturacion
{
    /// <summary>
    /// Identificación del DTE
    /// </summary>
    public class IdentificacionDTE
    {
        /// <summary>
        /// Tipo de DTE
        /// </summary>
        public Enum.TipoDTE.DTEType TipoDTE { get; set; }

        /// <summary>
        /// Folio del Documento Eletrónico
        /// </summary>
        public long Folio { get; set; }

        /// <summary>
        /// Fecha Emisión Contable del DTE (AAAA-MM-DD)
        /// Do not set this property, set FechaEmision instead.
        /// </summary>
        public string FechaEmisionString { get; set; }

        /// <summary>
        /// Fecha Emisión Contable del DTE.
        /// </summary>
        public DateTime FchEmis { get { return DateTime.Parse(FechaEmisionString); } set { this.FechaEmisionString = value.ToString("yyyy-MM-dd"); } }

        /// <summary>
        /// Sólo para Notas de Crédito que no tienen derecho a Rebaja del Débito.
        /// 1: Nota de crédito sin derecho a descontar débito (Art 70 DL 825 y art. 38 reglamento DL 825.
        /// </summary>
        public int IndNoRebaja { get; set; }

        /// <summary>
        /// Indica si el documento acompaña bienes y el despacho es por cuenta del vendedor o del comprador. No se incluye si el documento no acompaña bienes o se trata de una Factura o Nota correspondiente a la prestación de servicios.
        /// </summary>
        public Enum.TipoDespacho.TipoDespachoEnum TipoDespacho { get; set; }

        /// <summary>
        /// Sólo para Guías de despacho.
        /// Indica si el traslado de mercadería es por Venta (valor 1) o por otros motivos que no corresponden a venta. (valores mayores a 1).
        /// 7: Para de devolución de mercaderías que fueron trasladadas para exportación desde la zona de embarque.
        /// 8 y 9: Para exportaciones, cuando se dirige la mercadería hacia el puerto, aeropuerto o aduana de embarque. 
        /// 9 : Entre otros, venta de mercaderías que se entregan en Zona Primaria de Aduanas para su exportación
        /// </summary>
        public Enum.TipoTraslado.TipoTrasladoEnum IndTraslado { get; set; }

        /// <summary>
        /// Describe modalidad de Impresión de la representación impresa en formato normal o en formato Ticket. Por omisión se asume "N".
        /// </summary>
        public Enum.TipoImpresion.TipoImpresionEnum TpoImpresion { get; set; }
        /// <summary>
        /// Indica si la transacción corresponde a la prestación de un servicio
        /// </summary>
        public Enum.IndicadorServicio.IndicadorServicioEnum IndServicio { get; set; }

        /// <summary>
        /// Indica si las líneas de detalle, descuentos y recargos se expresan en montos brutos. (Sólo para documentos sin impuestos adicionales).
        /// 1: Montos de líneas de detalle vienen expresados en montos brutos.
        /// </summary>
        public int MntBruto { get; set; }
        /// <summary>
        /// Indica en qué forma se pagará. En el caso de una Factura por “Entrega Gratuita”, se debe indicar el 3. Una Factura de este tipo no tiene derecho a crédito fiscal.
        /// </summary>
        public Enum.FormaPago.FormaPagoEnum FmaPago { get; set; }
        /// <summary>
        /// En el caso de Factura de exportación se refiere a la forma de pago del importador extranjero indicada en el DUS (acreditivo, cobranza, anticipo, contado) En el caso de una Factura de exportación por “Muestras sin carácter comercial”, según las normas de Aduanas, debe indicar el Cod. 21. 
        /// </summary>
        public Enum.CodigosAduana.FormaPagoExportacionEnum FmaPagExp { get; set; }

        /// <summary>
        /// Sólo se utiliza si la factura ha sido cancelada antes de la fecha de emisión. (AAAA-MM-DD).
        /// Campo Obligatorio para Factura de exportación cuando en “Forma de Pago Exportación” se indique “anticipo”
        /// Do not set this property, set FechaCancelacion instead
        /// </summary>
        public string FechaCancelacionString { get; set; }

        /// <summary>
        /// Sólo se utiliza si la factura ha sido cancelada antes de la fecha de emisión. (AAAA-MM-DD).
        /// Campo Obligatorio para Factura de exportación cuando en “Forma de Pago Exportación” se indique “anticipo”
        /// </summary>
        public DateTime FchCancel { get { return DateTime.Parse(FechaCancelacionString); } set { this.FechaCancelacionString = value.ToString("yyyy-MM-dd"); } }

        /// <summary>
        /// Al momento de emitirse el documento.
        /// </summary>
        public int MntCancel { get; set; }

        /// <summary>
        /// Al momento de emitirse el documento.
        /// </summary>
        public int SaldoInsol { get; set; }

        /// <summary>
        /// Tabla de montos de pago. Opcional para especificar la programación de pagos del documento.
        /// Hasta 30 repeticiones.
        /// </summary>
        public List<MontoPagoItem> MntPagos { get; set; }

        /// <summary>
        /// Periodo de facturación para servicios periódicos. Fecha desde. AAAA-MM-DD
        /// Fecha inicial del servicio facturado.
        /// Do not set this property, set PeriodoDesde instead.
        /// </summary>
        public string PeriodoDesdeString { get; set; }

        /// <summary>
        /// Periodo de facturación para servicios periódicos. Fecha desde. AAAA-MM-DD
        /// Fecha inicial del servicio facturado.
        /// Do not set this property, set PeriodoDesde instead.
        /// </summary>
        public DateTime PeriodoDesde { get { return DateTime.Parse(PeriodoDesdeString); } set { this.PeriodoDesdeString = value.ToString("yyyy-MM-dd"); } }

        /// <summary>
        /// Periodo de facturación para servicios periódicos. Fecha hasta. AAAA-MM-DD
        /// Fecha final del servicio facturado.
        /// Do not set this property, set PeriodoHasta instead.
        /// </summary>
        public string PeriodoHastaString { get; set; }

        /// <summary>
        /// Periodo de facturación para servicios periódicos. Fecha desde. AAAA-MM-DD
        /// Fecha inicial del servicio facturado.
        /// </summary>
        public DateTime PeriodoHasta { get { return DateTime.Parse(PeriodoHastaString); } set { this.PeriodoHastaString = value.ToString("yyyy-MM-dd"); } }

        /// <summary>
        /// Indica en qué modalidad se pagará.
        /// </summary>
        public Enum.MedioPago.MedioPagoEnum MedioPago { get; set; }

        /// <summary>
        /// Tipo de cuenta de pago.
        /// </summary>
        public Enum.TipoCuentaPago.TipoCuentaPagoEnum TpoCtaPago { get; set; }

        private string _cuentaPago;
        /// <summary>
        /// Numero de la cuenta de pago
        /// </summary>
        public string NumCtaPago { get { return _cuentaPago.Truncate(20); } set { _cuentaPago = value; } }

        private string _bancoPago;
        /// <summary>
        /// Banco de la cuenta de pago
        /// </summary>
        public string BcoPago { get { return _bancoPago.Truncate(40); } set { _bancoPago = value; } }

        private string _terminoPagoCodigo;
        /// <summary>
        /// Es un código acordado entre las empresas, que indica términos de referencia Ejemplos: Fecha Recepción Factura (FRF), o Fecha entrega Mercaderías (FEM), etc. 
        /// </summary>
        public string TermPagoCdg { get { return _terminoPagoCodigo.Truncate(4); } set { _terminoPagoCodigo = value; } }

        private string _terminoPagoGlosa;
        /// <summary>
        /// Glosa que describe las condiciones del pago del documento, codificado en el campo: “Términos del pagoCódigo” 
        /// En documentos de Exportación Es obligatorio si se indicó el campo: Código de termino de pago
        /// </summary>
        public string TermPagoGlosa { get { return _terminoPagoGlosa.Truncate(100); } set { _terminoPagoGlosa = value; } }

        /// <summary>
        /// Cantidad de días de acuerdo al código de Términos de pago: Ejemplo  5 días Fecha entrega Mercaderías (Día = 5, Código =FEM)
        /// </summary>
        public int TermPagoDias { get; set; }

        /// <summary>
        /// Fecha de vencimiento (AAAA-MMDD)
        /// Do not set this property, set FechaVencimiento instead.
        /// </summary>
        public string FechaVencimientoString { get; set; }

        /// <summary>
        /// Fecha de vencimiento (AAAA-MMDD)
        /// </summary>
        public DateTime FchVenc { get { return DateTime.Parse(FechaVencimientoString); } set { this.FechaVencimientoString = value.ToString("yyyy-MM-dd"); } }

        public int IndMntNeto { get; set; }
        public IdentificacionDTE()
        {
            // IndicadorServicioBoleta = Enum.IndicadorServicio.IndicadorServicioBoletaEnum.NotSet;
            IndServicio = Enum.IndicadorServicio.IndicadorServicioEnum.NotSet;
            IndNoRebaja = 0;
            TipoDespacho = Enum.TipoDespacho.TipoDespachoEnum.NotSet;
            IndTraslado = Enum.TipoTraslado.TipoTrasladoEnum.NotSet;
            TpoImpresion = Enum.TipoImpresion.TipoImpresionEnum.N;
            MntBruto = 0;
            FmaPago = Enum.FormaPago.FormaPagoEnum.NotSet;
            FmaPagExp = 0;
            FchCancel = DateTime.MinValue;
            MntCancel = 0;
            SaldoInsol = 0;
            MntPagos = new List<MontoPagoItem>();
            PeriodoDesde = DateTime.MinValue;
            PeriodoHasta = DateTime.MinValue;
            MedioPago = Enum.MedioPago.MedioPagoEnum.NotSet;
            TpoCtaPago = Enum.TipoCuentaPago.TipoCuentaPagoEnum.NotSet;
            NumCtaPago = string.Empty;
            BcoPago = string.Empty;
            TermPagoCdg = string.Empty;
            TermPagoGlosa = string.Empty;
            TermPagoDias = 0;
            FchVenc = DateTime.MinValue;
        }
    }
}
