using SDKSimpleFactura.Enum;

namespace SDKSimpleFactura.Models.Request
{
    /// <summary>
    /// Request para anular una BHE emitida (/bhe/anular)
    /// </summary>
    public class AnularBheRequest
    {
        public string RutEmpresa { get; set; }
        public long Folio { get; set; }
        public AnulacionBoletaHonorarioEnum Motivo { get; set; }

        public AnularBheRequest()
        {
            RutEmpresa = string.Empty;
        }
    }
}
