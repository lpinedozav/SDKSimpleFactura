using SDKSimpleFactura.Models;
using SDKSimpleFactura.Models.Facturacion;

namespace SDKSimpleFactura.Services
{
    public class SucursalService : BaseService
    {
        public SucursalService(HttpClient httpClient) : base(httpClient) { }
        public async Task<Response<List<Sucursal>>> ListadoSucursalesAsync(Credenciales credenciales)
        {
            var url = "/branchOffices";
            return await PostAsync<Credenciales, Response<List<Sucursal>>>(url, credenciales);
        }
    }
}
