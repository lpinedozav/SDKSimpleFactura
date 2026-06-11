using static SDKSimpleFactura.Enum.Ambiente;

namespace SDKSimpleFactura.Models.Request
{
    /// <summary>
    /// Request para anular una guía de despacho por folio (/dte/anularGuia)
    /// </summary>
    public class AnularGuiaRequest
    {
        public string RutEmpresa { get; set; }
        public long Folio { get; set; }
        public AmbienteEnum Ambiente { get; set; }

        public AnularGuiaRequest()
        {
            RutEmpresa = string.Empty;
        }
    }
}
