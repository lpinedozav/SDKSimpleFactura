using System.Collections.Generic;
using System.Threading.Tasks;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.Request;
using SDKSimpleFactura.Models.Response;

namespace SDKSimpleFactura.Interfaces
{
    public interface IProductosService
    {
        Task<Response<List<ProductoEnt>>?> AgregarProductosAsync(DatoExternoRequest request);
        Task<Response<List<ProductoExternoEnt>>?> ListarProductosAsync(Credenciales credenciales);
    }
}
