using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class GuiaExportacion
    {
        /// <summary>
        /// Sólo para Guía de Despacho:
        /// 1: Exportador
        /// 2: Agente de Aduana (En la devolución de mercaderías de Aduanas.
        /// 3: Vendedor (Entre otros, se refiere a aquel Productor que vende mercadería con entrega en Zona Primaria).
        /// 4: Contribuyente autorizado expresamente por el SII.
        /// 
        /// Obligatorio si "Documento.Encabezado.IdentifadorDTE.Indicador tipo traslado" con valor 8 y 9.
        /// </summary>
        public Enum.CodigoTraslado.CodigoTrasladoEnum CdgTraslado { get; set; }

        /// <summary>
        /// Sólo para Guía de Despacho: 
        /// Corresponde al N° de Resolución del SII donde en casos especiales se autoriza al contribuyente a emitir guías de despacho. 
        /// Campo obligatorio cuando se indique 4 (ContribuyenteAutorizado) en el Código de emisor de traslado excepcional
        /// </summary>
        public int FolioAut { get; set; }

        /// <summary>
        /// Sólo para Guía de Despacho: 
        /// Fecha de emisión de la Resolución de autorización (AAAA-MM-DD)
        /// Campo obligatorio cuando se indique 4 (ContribuyenteAutorizado) en el Código Emisor Traslado Excepcional.
        /// Do not set this property, set FechaAutorizacion instead.
        /// </summary>
        public string FechaAutorizacionString { get; set; }

        /// <summary>
        /// Sólo para Guía de Despacho: 
        /// Fecha de emisión de la Resolución de autorización (AAAA-MM-DD)
        /// Campo obligatorio cuando se indique 4 (ContribuyenteAutorizado) en el Código Emisor Traslado Excepcional.
        /// </summary>
        public DateTime FchAut { get { return DateTime.Parse(FechaAutorizacionString); } set { this.FechaAutorizacionString = value.ToString("yyyy-MM-dd"); } }

        public GuiaExportacion()
        {
            CdgTraslado = Enum.CodigoTraslado.CodigoTrasladoEnum.NotSet;
            FolioAut = 0;
            FchAut = DateTime.MinValue;
        }
    }
}
