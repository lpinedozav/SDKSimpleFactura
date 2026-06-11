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
        public async Task<Response<ReceptorEnt>> ClientXRutAsync(Credenciales credenciales, string rut)
        {
            var url = $"/clients/{rut}";
            var result = await _apiService.PostAsync<Credenciales, Response<ReceptorEnt>>(url, credenciales);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<ReceptorEnt>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<List<ReceptorExternoEnt>>?> EditarClientesAsync(EditarClienteRequest request)
        {
            var url = "/editClients";
            var result = await _apiService.PostAsync<EditarClienteRequest, Response<List<ReceptorExternoEnt>>>(url, request);
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
        public async Task<Response<ContribuyenteSiiEnt>?> ObtenerContribuyenteSiiAsync(Credenciales credenciales, string rut)
        {
            var url = $"/contribuyentes/correo-intercambio/{rut}";
            var result = await _apiService.PostAsync<Credenciales, Response<ContribuyenteSiiEnt>>(url, credenciales);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<ContribuyenteSiiEnt>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
    }
}
