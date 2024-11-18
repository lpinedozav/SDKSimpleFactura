using SDKSimpleFactura.Models.Productos;
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
