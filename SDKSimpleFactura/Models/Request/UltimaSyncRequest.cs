using SDKSimpleFactura.Enum;
using SDKSimpleFactura.Models.Facturacion;

namespace SDKSimpleFactura.Models.Request
{
    /// <summary>
    /// Request para consultar la última sincronización con el SII (/sii/lastsync/{mes}/{anio})
    /// </summary>
    public class UltimaSyncRequest
    {
        public Credenciales Credenciales { get; set; }
        public SyncTypeEnum Tipo { get; set; }

        public UltimaSyncRequest()
        {
            Credenciales = new Credenciales();
        }
    }
}
