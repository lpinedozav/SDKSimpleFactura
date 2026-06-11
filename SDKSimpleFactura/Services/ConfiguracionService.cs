using Newtonsoft.Json;
using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.Request;
using SDKSimpleFactura.Models.Response;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
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
        public async Task<Response<List<ActividadeconomicaApiEnt>>?> ObtenerActividadesEconomicasAsync()
        {
            var url = "/actividades-economicas";
            var result = await _apiService.GetAsync<Response<List<ActividadeconomicaApiEnt>>>(url);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<List<ActividadeconomicaApiEnt>>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<LastSyncResponse>?> ObtenerUltimaSincronizacionSiiAsync(UltimaSyncRequest request, int mes, int anio)
        {
            var url = $"/sii/lastsync/{mes}/{anio}";
            var result = await _apiService.PostAsync<UltimaSyncRequest, Response<LastSyncResponse>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<LastSyncResponse>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<TokenExpireEnt?> TiempoExpiracionTokenAsync()
        {
            var url = "/token/expire";
            var result = await _apiService.GetAsync<TokenExpireEnt>(url);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return null;
        }
        public async Task<Response<bool>> SubirCertificadoAsync(CertificadoUploadRequest certificadoData, string pathCertificado)
        {
            var url = "/certificado/subir";
            using (var content = new MultipartFormDataContent())
            {
                var jsonCertificadoData = JsonConvert.SerializeObject(certificadoData);
                var certificadoDataContent = new StringContent(jsonCertificadoData, Encoding.UTF8, "application/json");
                content.Add(certificadoDataContent, "certificadoData");

                using (var stream = File.OpenRead(pathCertificado))
                {
                    var fileContent = new StreamContent(stream);
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    content.Add(fileContent, "certificado", Path.GetFileName(pathCertificado));

                    var result = await _apiService.PostMultipartAsync<Response<bool>>(url, content);
                    if (result.IsSuccess)
                    {
                        return result.Data;
                    }
                    return new Response<bool>
                    {
                        Status = result.StatusCode,
                        Message = result.Errores,
                        Data = false
                    };
                }
            }
        }
        public async Task<Response<bool>> SubirLogoAsync(Credenciales credenciales, string pathLogo)
        {
            var url = "/upload-logo";
            using (var content = new MultipartFormDataContent())
            {
                var jsonCredenciales = JsonConvert.SerializeObject(credenciales);
                var credencialesContent = new StringContent(jsonCredenciales, Encoding.UTF8, "application/json");
                content.Add(credencialesContent, "CredencialesJson");

                using (var stream = File.OpenRead(pathLogo))
                {
                    var fileContent = new StreamContent(stream);
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    content.Add(fileContent, "Logo", Path.GetFileName(pathLogo));

                    var result = await _apiService.PostMultipartAsync<Response<bool>>(url, content);
                    if (result.IsSuccess)
                    {
                        return result.Data;
                    }
                    return new Response<bool>
                    {
                        Status = result.StatusCode,
                        Message = result.Errores,
                        Data = false
                    };
                }
            }
        }
    }
}
