using SDKSimpleFactura.Models;
using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Models.Facturacion;

namespace SDKSimpleFactura.Services
{
    public class SucursalService : ISucursalService
    {
        private readonly IApiService _apiService;
        public SucursalService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<Response<List<Sucursal>>?> ListadoSucursalesAsync(Credenciales credenciales)
        {
            var url = "/branchOffices";
            var result = await _apiService.PostAsync<Credenciales, Response<List<Sucursal>>>(url, credenciales);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<List<Sucursal>>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
    }
}
