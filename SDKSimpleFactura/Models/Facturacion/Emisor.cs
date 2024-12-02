using SDKSimpleFactura.Helpers;
using System.Collections.Generic;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class Emisor
    {
        /// <summary>
        /// Rut del emisor del DTE
        /// Con guión y dígito verificador.
        /// Cuerpo numérico entre 100.000 y 99 millones, guión y dígito veridicador alfanumérico entre 0 y 9 o K.
        /// </summary>
        public string RUTEmisor { get; set; }

        /// <summary>
        /// Nombre o razón social del Emisor
        /// </summary>
        public string? RznSoc { get { return _razonSocial.Truncate(70); } set { _razonSocial = value; } }

        private string? _razonSocial;

        public string? RznSocEmisor { get { return _razonSocialBoleta.Truncate(100); } set { _razonSocialBoleta = value; } }
        private string? _razonSocialBoleta;

        private string? _giro;
        private string? _giroEmisor;
        /// <summary>
        /// Glosa indicando giro del emisor. No es preciso registrar todos los giros, sino que se podrá registrar sólo el giro que corresponde a la transacción.
        /// </summary>
        public string? GiroEmis { get { return _giro.Truncate(80); } set { _giro = value; } }

        public string? GiroEmisor { get { return _giroEmisor.Truncate(80); } set { _giroEmisor = value; } }

        private List<string> _telefono;
        /// <summary>
        /// Primer teléfono del emisor
        /// </summary>
        public List<string> Telefono { get { return _telefono; } set { _telefono = value; _telefono.ForEach(x => x.Truncate(20)); } }

        /// <summary>
        /// Correo electrónico de contacto en empresa del receptor.
        /// </summary>
        public string? CorreoEmisor { get; set; }

        /// <summary>
        /// Código de actividad económica del emisor.
        /// Relevante para el DTE.
        /// Se acepta un máximo de 4 Códigos de actividad económica del emisor del DTE. 
        /// Se puede incluir sólo el código que corresponde a la transacción.  
        /// Número debe estar registrado en el SII
        /// </summary>
        public List<int> Acteco { get; set; }

        /// <summary>
        /// Emisor de una Guía de despacho para exportación.
        /// </summary>
        public GuiaExportacion? GuiaExport { get; set; }

        private string _sucursal;
        /// <summary>
        /// Sucursal que emite el DTE.
        /// Indica nombre de la sucursal que emite el Documento. Corresponde a un dato administrado por el emisor que puede ser un texto o un número
        /// </summary>
        public string Sucursal { get { return _sucursal.Truncate(20); } set { _sucursal = value; } }

        /// <summary>
        /// Código numérico entregado por el SII, que identifica a cada sucursal que está identificada en el Servicio de Impuestos Internos.
        /// Si no hay sucursales se puede omitir.
        /// Deber corresponder a un código registrado en el SII
        /// </summary>
        public int CdgSIISucur { get; set; }

        private string _dirOrigen;
        /// <summary>
        /// Datos correspondientes a Dirección desde donde se despachan bienes o de la sucursal que emite el documento si no hay despacho de bienes. 
        /// </summary>
        public string DirOrigen { get { return _dirOrigen.Truncate(70); } set { _dirOrigen = value; } }

        /// <summary>
        /// Comuna de origen
        /// Análogo a dirección de origen
        /// </summary>
        public string CmnaOrigen { get; set; }

        /// <summary>
        /// Ciudad de origen
        /// Análogo a dirección de origen.
        /// </summary>
        public string CiudadOrigen { get; set; }

        private string _codigoVendedor;
        /// <summary>
        /// Código del vendedor.
        /// Glosa con identificador del vendedor.
        /// </summary>
        public string CdgVendedor { get { return _codigoVendedor.Truncate(60); } set { _codigoVendedor = value; } }

        private string _idAdicionalEmisor;
        /// <summary>
        /// Identificador Adicional del Emisor
        /// para documento utilizados en exportaciones.
        /// Codigo de identificación adicional para uso libre.
        /// </summary>
        public string IdAdicEmisor { get { return _idAdicionalEmisor.Truncate(20); } set { _idAdicionalEmisor = value; } }


        public Emisor()
        {
            RUTEmisor = string.Empty;
            RznSoc = string.Empty;
            GiroEmis = string.Empty;
            Acteco = new List<int>();
            Telefono = new List<string>();
            CorreoEmisor = string.Empty;
            GuiaExport = null;
            Sucursal = string.Empty;
            CdgSIISucur = 0;
            DirOrigen = string.Empty;
            CmnaOrigen = string.Empty;
            CiudadOrigen = string.Empty;
            CdgVendedor = string.Empty;
            IdAdicEmisor = string.Empty;
        }
    }
}
