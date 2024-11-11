using SDKSimpleFactura.Models;
using SDKSimpleFactura.Models.Folios;

namespace SDKSimpleFactura.Services
{
    public class FolioService : BaseService
    {
        public FolioService(HttpClient httpClient) : base(httpClient) { }
        public async Task<Response<int>> ConsultaFoliosDisponiblesAsync(SolicitudFoliosRequest request)
        {
            var url = "/folios/consultar/disponibles";
            return await PostAsync<SolicitudFoliosRequest, Response<int>>(url, request);
        }
        public async Task<Response<TimbrajeApiEnt?>> SolicitarFoliosAsync(FolioRequest request)
        {
            var url = "/folios/solicitar";
            return await PostAsync<FolioRequest, Response<TimbrajeApiEnt?>>(url, request);
        }
        public async Task<Response<List<TimbrajeApiEnt>?>> ConsultarFoliosAsync(FolioRequest request)
        {
            var url = "/folios/consultar";
            return await PostAsync<FolioRequest, Response<List<TimbrajeApiEnt>?>>(url, request);
        }
        public async Task<Response<List<FoliosAnulablesEnt>>> FoliosSinUsoAsync(SolicitudFoliosRequest request)
        {
            var url = "/folios/consultar/sin-uso";
            return await PostAsync<SolicitudFoliosRequest, Response<List<FoliosAnulablesEnt>>>(url,request);
        }
    }
}
