using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Models;
using SDKSimpleFactura.Models.Folios;

namespace SDKSimpleFactura.Services
{
    public class FolioService : IFolioService
    {
        private readonly IApiService _apiService;
        public FolioService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<Response<int>?> ConsultaFoliosDisponiblesAsync(SolicitudFoliosRequest request)
        {
            var url = "/folios/consultar/disponibles";
            var result = await _apiService.PostAsync<SolicitudFoliosRequest, Response<int>>(url, request);
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
            var result = await _apiService.PostAsync<FolioRequest, Response<TimbrajeApiEnt?>>(url, request);
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
            var result = await _apiService.PostAsync<FolioRequest, Response<List<TimbrajeApiEnt>?>>(url, request);
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
            var result = await _apiService.PostAsync<SolicitudFoliosRequest, Response<List<FoliosAnulablesEnt>>>(url, request);
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
