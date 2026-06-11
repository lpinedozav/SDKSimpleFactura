using SDKSimpleFactura.Enum;

namespace SDKSimpleFactura.Models.Request
{
    /// <summary>
    /// Request para observar una BHE recibida (/bhe/observacion)
    /// </summary>
    public class BheObservacionRequest
    {
        public string RutEmpresa { get; set; }
        public string rutContribuyente { get; set; }
        public long Folio { get; set; }
        public ObservacionBoletaHonorarioEnum Observacion { get; set; }

        public BheObservacionRequest()
        {
            RutEmpresa = string.Empty;
            rutContribuyente = string.Empty;
        }
    }
}
