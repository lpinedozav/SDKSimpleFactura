using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.Response;

namespace SDKSimpleFactura.Services
{
    public class ConfiguracionService : IConfiguracionService
    {
        private readonly IApiService _apiService;
        public ConfiguracionService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<Response<EmisorApiEnt>?> DatosEmpresaAsync(Credenciales credenciales)
        {
            var url = "/datosEmpresa";
            var result = await _apiService.PostAsync<Credenciales, Response<EmisorApiEnt>>(url, credenciales);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<EmisorApiEnt>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
    }
}
