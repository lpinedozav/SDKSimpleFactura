using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models;

namespace SDKSimpleFactura.Interfaces
{
    public interface ISucursalService
    {
        Task<Response<List<Sucursal>>?> ListadoSucursalesAsync(Credenciales credenciales);
    }
}
