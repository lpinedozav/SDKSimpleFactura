using SDKSimpleFactura.Models;
using SDKSimpleFactura.Models.Clientes;
using SDKSimpleFactura.Models.Facturacion;

namespace SDKSimpleFactura.Services
{
    public class ConfiguracionService : BaseService
    {
        public ConfiguracionService(HttpClient httpClient) : base(httpClient) { }
        public async Task<Response<EmisorApiEnt>?> DatosEmpresaAsync(Credenciales credenciales)
        {
            var url = "/datosEmpresa";
            var result = await PostAsync<Credenciales, Response<EmisorApiEnt>>(url, credenciales);
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
