using SDKSimpleFactura.Enum;
using static SDKSimpleFactura.Enum.Ambiente;
using static SDKSimpleFactura.Enum.TipoDTE;


namespace SDKSimpleFactura.Models.Facturacion
{
    public class ListaDteRequest
    {
        public Credenciales Credenciales { get; set; }

        public AmbienteEnum Ambiente { get; set; }
        public long? Folio { get; set; }
        public DTEType? CodigoTipoDte { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }
        public TipoSalida Salida { get; set; }
        public string? RutEmisor { get; set; }
    }
}
