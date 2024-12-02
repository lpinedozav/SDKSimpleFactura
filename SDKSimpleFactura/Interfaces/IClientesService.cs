using System.Collections.Generic;
using System.Threading.Tasks;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.Request;
using SDKSimpleFactura.Models.Response;

namespace SDKSimpleFactura.Interfaces
{
    public interface IClientesService
    {
        Task<Response<List<ReceptorExternoEnt>>?> AgregarClientesAsync(DatoExternoRequest request);
        Task<Response<List<ReceptorExternoEnt>>?> ListarClientesAsync(Credenciales credenciales);
    }
}
