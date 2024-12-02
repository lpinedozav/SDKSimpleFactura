using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Models.Request;
using SDKSimpleFactura.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SDKSimpleFactura.Services
{
    public class ClientesService : IClientesService
    {
        private readonly IApiService _apiService;
        public ClientesService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<Response<List<ReceptorExternoEnt>>?> AgregarClientesAsync(DatoExternoRequest request)
        {
            var url = "/addClients";
            var result = await _apiService.PostAsync<DatoExternoRequest, Response<List<ReceptorExternoEnt>>>(url, request);
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
            var result = await _apiService.PostAsync<Credenciales, Response<List<ReceptorExternoEnt>>>(url, credenciales);
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
