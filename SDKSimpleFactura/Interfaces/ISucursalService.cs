using System.Collections.Generic;
using System.Threading.Tasks;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.Response;

namespace SDKSimpleFactura.Interfaces
{
    public interface ISucursalService
    {
        Task<Response<List<SucursalEnt>>?> ListadoSucursalesAsync(Credenciales credenciales);
    }
}
