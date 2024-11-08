using SDKSimpleFactura.Models.Clientes;
using SDKSimpleFactura.Models;
using SDKSimpleFactura.Models.Productos;
using SDKSimpleFactura.Models.Facturacion;
namespace SDKSimpleFactura.Services
{
    public class ClientesService : BaseService
    {
        public ClientesService(HttpClient httpClient) : base(httpClient) { }
        public async Task<Response<ReceptorExternoEnt>> AgregarClientesAsync(DatoExternoRequest request)
        {
            var url = "/addClients";
            return await PostAsync<DatoExternoRequest, Response<ReceptorExternoEnt>>(url, request);
        }
        public async Task<Response<List<ReceptorExternoEnt>>> ListarClientes(Credenciales credenciales)
        {
            var url = "/clients";
            return await PostAsync<Credenciales, Response<List<ReceptorExternoEnt>>>(url, credenciales);
        }
    }
}
