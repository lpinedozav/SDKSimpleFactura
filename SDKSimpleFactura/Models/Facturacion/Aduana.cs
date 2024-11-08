using SDKSimpleFactura.Helpers;
namespace SDKSimpleFactura.Models.Facturacion
{
    public class Aduana
    {
        /// <summary>
        /// Código según tabla "Modalidad de Venta" de aduana.
        /// Se refiere a si la exportación se realiza bajo venta, En consignación, a firme, en Consignación con mínimo a firme, etc.)
        /// Campo Obligatorio para Factura de Exportación, excepto cuando en el Campo “Indicador Servicio” se indicó 3 (Factura de servicios), 4 (Servicios Hotelería) o 5 (Transporte Terrestre Internacional). 
        /// </summary>
        public Enum.CodigosAduana.ModalidadVenta CodModVenta { get; set; }
        public bool ShouldSerializeCodigoModalidadVenta() { return CodModVenta != Enum.CodigosAduana.ModalidadVenta.NotSet; }

        /// <summary>
        /// Código según Tabla "Cláusula compra-venta" de aduana.
        /// Se refiere a la cláusula de venta indicada en el DUS ( FOB, CIF, etc.).
        /// Campo Obligatorio, excepto cuando en el Campo “Indicador Servicio” se indicó 3 (Factura de servicios), 4 (Servicios Hotelería) o 5 (Transporte Terrestre Internacional). 
        /// </summary>
        public Enum.CodigosAduana.ClausulaCompraVenta CodClauVenta { get; set; }
        private double _totalClausulaVenta { get; set; }

        /// <summary>
        /// Total cláusula de venta.
        /// Corresponde al valor total de la exportación a pagar por el importador según la cláusula de venta acordada entre las partes y que se indica en el DUS. (No incluye comisiones ni otros gastos deducibles en el exterior).
        /// Campo Obligatorio, excepto cuando en el Campo “Indicador Servicio” se indicó 3 (Factura de servicios), 4 (Servicios Hotelería) o 5 (Transporte Terrestre Internacional). 
        /// </summary>
        public double TotClauVenta { get { return Math.Round(_totalClausulaVenta, 2); } set { _totalClausulaVenta = value; } }

        /// <summary>
        /// Indicar el código de la vía de transporte utilizada para trasnportar la mercadería, según tabla "Vías de transporte" de aduana.
        /// Corresponde a la vía de transporte por donde se envía la mercadería (aéreo, terrestre, marítimo, etc) al extranjero.
        /// Campo obligatorio, a excepción cuando en el “Indicador Servicio” se registra la opción N° 4 (Servicios de hotelería)
        /// </summary>
        public Enum.CodigosAduana.ViasdeTransporte CodViaTransp { get; set; }

        private string _nombreTransporte;
        /// <summary>
        /// Nombre o identificación del medio de transporte.
        /// Corresponde al nombre o glosa de la nave transportista. 
        /// </summary>
        public string NombreTransp { get { return _nombreTransporte.Truncate(40); } set { _nombreTransporte = value; } }

        /// <summary>
        /// Rut compañía transportadora.
        /// Para doctos. utilizados en exportación. 
        /// Señale el Rol Unico Tributario (RUT) de la compañía transportista indicada en el DUS. Si ésta es extranjera, señale el RUT de la Agencia que la representa en Chile.
        /// </summary>
        public string RUTCiaTransp { get; set; }

        private string _nombreCiaTransporte;
        /// <summary>
        /// Nombre compañía transportadora
        /// Nombre de la Cía. transportadora declarada en el DUS.
        /// </summary>
        public string NomCiaTransp { get { return _nombreCiaTransporte.Truncate(40); } set { _nombreCiaTransporte = value; } }

        private string _idAdicionalCiaTransporte;
        /// <summary>
        /// Identificador adicional de la compañía transportadora.
        /// Identificación adicional para uso libre.
        /// </summary>
        public string IdAdicTransp { get { return _idAdicionalCiaTransporte.Truncate(20); } set { _idAdicionalCiaTransporte = value; } }

        private string _booking;
        /// <summary>
        /// Número de reserva del operador.
        /// Número de Booking o Reserva del operador.
        /// </summary>
        public string Booking { get { return _booking.Truncate(20); } set { _booking = value; } }

        private string _codigoOperador;
        /// <summary>
        /// Código del operador.
        /// </summary>
        public string Operador { get { return _codigoOperador.Truncate(20); } set { _codigoOperador = value; } }

        /// <summary>
        /// Código del puerto de embarque de mercacías, según tabla de Aduana.
        /// En Guías: obligatorio sólo para Indicador tipo traslado = 8 (Traslado para exportación) y 9 (Venta para exportación).
        /// En Facturas de Exportación: Obligatorio excepto cuando el “Indicador Servicio” = 4 (Servicios de hotelería).
        /// </summary>
        public Enum.CodigosAduana.Puertos CodPtoEmbarque { get; set; }

        private string _idAdicionalPtoEmbarque;
        /// <summary>
        /// Identificador adicional del puerto de embarque.
        /// Identificación adicional para uso libre.
        /// </summary>
        public string IdAdicPtoEmb { get { return _idAdicionalPtoEmbarque.Truncate(20); } set { _idAdicionalPtoEmbarque = value; } }

        /// <summary>
        /// Código del puerto de desembarque según tabla de Aduana.
        /// En Guías: obligatorio sólo para Indicador tipo traslado = 8 (Traslado para exportación) y 9 (Venta para exportación).
        /// En Facturas de Exportación: Obligatorio excepto cuando el “Indicador Servicio” = 4 (Servicios de hotelería).
        /// </summary>
        public Enum.CodigosAduana.Puertos CodPtoDesemb { get; set; }

        private string _idAdicionalPtoDesembarque;
        /// <summary>
        /// Identificador adicional del puerto de desembarque.
        /// Identificación adicional para uso libre.
        /// </summary>
        public string IdAdicPtoDesemb { get { return _idAdicionalPtoDesembarque.Truncate(20); } set { _idAdicionalPtoDesembarque = value; } }

        /// <summary>
        /// Tara
        /// </summary>
        public int Tara { get; set; }

        /// <summary>
        /// Código de la unidad de medida según tabla de Aduana.
        /// Indique la unidad de medida en la que se encuentra expresado la Tara.
        /// </summary>
        public Enum.CodigosAduana.UnidadMedida CodUnidMedTara { get; set; }

        private double _pesoBruto;

        /// <summary>
        /// Sumatoria de los pesos brutos de todos los ítems del documento.
        /// En Guías: obligatorio sólo para Indicador tipo traslado = 8 (Traslado para exportación) y 9 (Venta para exportación).
        /// </summary>
        public double PesoBruto { get { return Math.Round(_pesoBruto, 2); } set { _pesoBruto = value; } }

        /// <summary>
        /// Indique la unidad de medida en la que se encuentra expresado el peso bruto de la mercadería, según tabla de Aduana.
        /// En Guías: obligatorio sólo para Indicador tipo traslado = 8 (Traslado para exportación) y 9 (Venta para exportación).
        /// </summary>
        public Enum.CodigosAduana.UnidadMedida CodUnidPesoBruto { get; set; }

        private double _pesoNeto;

        /// <summary>
        /// Sumatoria de los pesos netos de todos los ítems del documento.
        /// </summary>
        public double PesoNeto { get { return Math.Round(_pesoNeto, 2); } set { _pesoNeto = value; } }

        /// <summary>
        /// Indique la unidad de medida en la que se encuentra expresado el peso neto de la mercadería, según tabla de Aduana.
        /// </summary>
        public Enum.CodigosAduana.UnidadMedida CodUnidPesoNeto { get; set; }

        /// <summary>
        /// Indique el total de items del documento
        /// </summary>
        public int TotItems { get; set; }

        /// <summary>
        /// Cantidad de bultos que ampara el documento.
        /// En Guías: obligatorio sólo para Indicador tipo traslado = 8 (Traslado para exportación) y 9 (Venta para exportación).
        /// </summary>
        public int TotBultos { get; set; }

        /// <summary>
        /// Tabla de descripción de los distintos tipos de bultos.
        /// </summary>
        public List<TipoBulto> TipoBultos { get; set; }

        private double _montoFlete;

        /// <summary>
        /// Montos del flete, según moneda de venta.
        /// </summary>
        public double MntFlete { get { return Math.Round(_montoFlete, 4); } set { _montoFlete = value; } }

        private double _montoSeguro;

        /// <summary>
        /// Monto del seguro, según moneda de venta.
        /// </summary>
        public double MntSeguro { get { return Math.Round(_montoSeguro, 4); } set { _montoSeguro = value; } }

        /// <summary>
        /// Código del país del receptor extranjero de la mercadería, según tabla de países de Aduana.
        /// Análogo a Dirección Receptor.
        /// </summary>
        public Enum.CodigosAduana.Paises CodPaisRecep { get; set; }

        /// <summary>
        /// Código del país de destino extranjero de la mercadería, según tabla de países de Aduana.
        /// Análogo Dirección Destino.
        /// </summary>
        public Enum.CodigosAduana.Paises CodPaisDestin { get; set; }

        public Aduana()
        {
            CodModVenta = 0;
            CodClauVenta = 0;
            TotClauVenta = 0;
            CodViaTransp = 0;
            NombreTransp = string.Empty;
            RUTCiaTransp = string.Empty;
            NomCiaTransp = string.Empty;
            IdAdicTransp = string.Empty;
            Booking = string.Empty;
            Operador = string.Empty;
            CodPtoEmbarque = 0;
            IdAdicPtoEmb = string.Empty;
            CodPtoDesemb = 0;
            IdAdicPtoDesemb = string.Empty;
            Tara = 0;
            CodUnidMedTara = 0;
            PesoBruto = 0;
            CodUnidPesoBruto = 0;
            PesoNeto = 0;
            CodUnidPesoNeto = 0;
            TotItems = 0;
            TotBultos = 0;
            TipoBultos = new List<TipoBulto>();
            MntFlete = 0;
            MntSeguro = 0;
            CodPaisRecep = 0;
            CodPaisDestin = 0;
        }
    }
}
