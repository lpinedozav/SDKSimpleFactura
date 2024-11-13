using SDKSimpleFactura.Models.Productos;
using SDKSimpleFactura.Models;
using SDKSimpleFactura.Models.Facturacion;

namespace SDKSimpleFactura.Interfaces
{
    public interface IProductosService
    {
        Task<Response<List<ProductoEnt>>?> AgregarProductosAsync(DatoExternoRequest request);
        Task<Response<List<ProductoExternoEnt>>?> ListarProductosAsync(Credenciales credenciales);
    }
}
