using SDKSimpleFactura.Models;
using SDKSimpleFactura.Models.Folios;

namespace SDKSimpleFactura.Services
{
    public class FolioService : BaseService
    {
        public FolioService(HttpClient httpClient) : base(httpClient) { }
        public async Task<Response<int>?> ConsultaFoliosDisponiblesAsync(SolicitudFoliosRequest request)
        {
            var url = "/folios/consultar/disponibles";
            var result = await PostAsync<SolicitudFoliosRequest, Response<int>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<int>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = 0
            };
        }
        public async Task<Response<TimbrajeApiEnt>?> SolicitarFoliosAsync(FolioRequest request)
        {
            var url = "/folios/solicitar";
            var result = await PostAsync<FolioRequest, Response<TimbrajeApiEnt?>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<TimbrajeApiEnt>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<List<TimbrajeApiEnt>>?> ConsultarFoliosAsync(FolioRequest request)
        {
            var url = "/folios/consultar";
            var result = await PostAsync<FolioRequest, Response<List<TimbrajeApiEnt>?>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<List<TimbrajeApiEnt>>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<List<FoliosAnulablesEnt>>?> FoliosSinUsoAsync(SolicitudFoliosRequest request)
        {
            var url = "/folios/consultar/sin-uso";
            var result = await PostAsync<SolicitudFoliosRequest, Response<List<FoliosAnulablesEnt>>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<List<FoliosAnulablesEnt>>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
    }
}
