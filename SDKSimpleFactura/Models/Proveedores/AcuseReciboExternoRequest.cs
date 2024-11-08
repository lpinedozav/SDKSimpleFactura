using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Enum;

namespace SDKSimpleFactura.Models.Proveedores
{
    public class AcuseReciboExternoRequest
    {
        public Credenciales Credenciales { get; set; }
        public DteReferenciadoExterno DteReferenciadoExterno { get; set; }
        public ResponseType Respuesta { get; set; }
        public RejectionType TipoRechazo { get; set; }
        public string Comentario { get; set; }

    }
}
