using SDKSimpleFactura.Models.Clientes;
using SDKSimpleFactura.Models;
using SDKSimpleFactura.Models.Productos;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.BoletasHonorarios;
namespace SDKSimpleFactura.Services
{
    public class ClientesService : BaseService
    {
        public ClientesService(HttpClient httpClient) : base(httpClient) { }
        public async Task<Response<List<ReceptorExternoEnt>>?> AgregarClientesAsync(DatoExternoRequest request)
        {
            var url = "/addClients";
            var result = await PostAsync<DatoExternoRequest, Response<List<ReceptorExternoEnt>>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<List<ReceptorExternoEnt>>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<List<ReceptorExternoEnt>>?> ListarClientesAsync(Credenciales credenciales)
        {
            var url = "/clients";
            var result = await PostAsync<Credenciales, Response<List<ReceptorExternoEnt>>>(url, credenciales);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<List<ReceptorExternoEnt>>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
    }
}
