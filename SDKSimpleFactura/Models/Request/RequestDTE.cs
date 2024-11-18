using SDKSimpleFactura.Enum;
using SDKSimpleFactura.Models.Facturacion;

namespace SDKSimpleFactura.Models.Request
{
    public class RequestDTE
    {
        public Documento? Documento { get; set; }
        public Exportaciones? Exportaciones { get; set; }
        public string? Observaciones { get; set; }
        public string? Cajero { get; set; }
        public string? TipoPago { get; set; }
        public int? Propina { get; set; }

        public RequestDTE(Emisor emisor, Receptor receptor, long folio, TipoDTE.DTEType tipo)
        {
            Documento = new Documento();

            Documento.Encabezado.Emisor = emisor;
            Documento.Encabezado.Receptor = receptor;

            Documento.Encabezado.IdDoc.Folio = folio;
            Documento.Encabezado.IdDoc.TipoDTE = tipo;
            Documento.Encabezado.IdDoc.FchEmis = DateTime.Now;

            //Para boletas electrónicas
            if (tipo == TipoDTE.DTEType.BoletaElectronica || tipo == TipoDTE.DTEType.BoletaElectronicaExenta)
            {
                Documento.Encabezado.IdDoc.IndServicio = IndicadorServicio.IndicadorServicioEnum.BoletaVentasYServicios;
            }
        }


        public RequestDTE()
        {
        }
    }
}
