using SDKSimpleFactura.Models;
using SDKSimpleFactura.Models.Facturacion;

namespace SDKSimpleFactura.Services
{
    public class ConfiguracionService : BaseService
    {
        public ConfiguracionService(HttpClient httpClient) : base(httpClient) { }
        public async Task<Response<EmisorApiEnt>> DatosEmpresaAsync(Credenciales credenciales)
        {
            var url = "/datosEmpresa";
            return await PostAsync<Credenciales,Response<EmisorApiEnt>>(url, credenciales);
        }
    }
}
