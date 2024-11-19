using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.Response;

namespace SDKSimpleFactura.Services
{
    public class SucursalService : ISucursalService
    {
        private readonly IApiService _apiService;
        public SucursalService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<Response<List<SucursalEnt>>?> ListadoSucursalesAsync(Credenciales credenciales)
        {
            var url = "/branchOffices";
            var result = await _apiService.PostAsync<Credenciales, Response<List<SucursalEnt>>>(url, credenciales);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<List<SucursalEnt>>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
    }
}
