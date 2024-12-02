using System.Collections.Generic;
using SDKSimpleFactura.Models.Facturacion;

namespace SDKSimpleFactura.Models.Request
{
    public class DatoExternoRequest
    {
        public Credenciales Credenciales { get; set; }
        public List<NuevoProductoExternoRequest>? Productos { get; set; }
        public List<NuevoReceptorExternoRequest>? Clientes { get; set; }
    }
}
