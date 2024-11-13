using SDKSimpleFactura.Models.Clientes;
using SDKSimpleFactura.Models.Productos;
using SDKSimpleFactura.Models;
using SDKSimpleFactura.Models.Facturacion;

namespace SDKSimpleFactura.Interfaces
{
    public interface IClientesService
    {
        Task<Response<List<ReceptorExternoEnt>>?> AgregarClientesAsync(DatoExternoRequest request);
        Task<Response<List<ReceptorExternoEnt>>?> ListarClientesAsync(Credenciales credenciales);
    }
}
