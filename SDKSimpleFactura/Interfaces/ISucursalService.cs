using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.Response;

namespace SDKSimpleFactura.Interfaces
{
    public interface ISucursalService
    {
        Task<Response<List<SucursalEnt>>?> ListadoSucursalesAsync(Credenciales credenciales);
    }
}
