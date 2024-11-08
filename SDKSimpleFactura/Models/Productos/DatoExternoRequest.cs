using SDKSimpleFactura.Models.Clientes;
using SDKSimpleFactura.Models.Facturacion;

namespace SDKSimpleFactura.Models.Productos
{
    public class DatoExternoRequest
    {
        public Credenciales Credenciales { get; set; }
        public List<NuevoProductoExternoRequest>? Productos { get; set; }
        public List<NuevoReceptorExternoRequest>? Clientes { get; set; }
    }
}
