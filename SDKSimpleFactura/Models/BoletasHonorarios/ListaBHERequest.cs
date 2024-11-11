using SDKSimpleFactura.Models.Facturacion;

namespace SDKSimpleFactura.Models.BoletasHonorarios
{
    public class ListaBHERequest
    {
        public Credenciales Credenciales { get; set; }
        public long? Folio { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }
       
    }
}
