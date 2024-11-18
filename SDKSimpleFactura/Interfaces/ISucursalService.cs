using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models;
using SDKSimpleFactura.Models.Response;

namespace SDKSimpleFactura.Interfaces
{
    public interface ISucursalService
    {
        Task<Response<List<Sucursal>>?> ListadoSucursalesAsync(Credenciales credenciales);
    }
}
