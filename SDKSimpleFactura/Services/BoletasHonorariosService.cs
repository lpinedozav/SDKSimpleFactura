using SDKSimpleFactura.Models;
using SDKSimpleFactura.Models.BoletasHonorarios;

namespace SDKSimpleFactura.Services
{
    public class BoletasHonorariosService : BaseService
    {
        public BoletasHonorariosService(HttpClient httpClient) : base(httpClient) { }
        public async Task<byte[]> ObtenerPDFBHEEmitidaAsync(BHERequest request)
        {
            var url = "/bhe/pdfIssuied";
            return await PostForByteArrayAsync<BHERequest> (url, request);
        }
        public async Task<Response<List<BHEEnt>>?> ListadoBHEEmitidasAsync(ListaBHERequest request)
        {
            var url = "/bhesIssued";
            var result = await PostAsync<ListaBHERequest, Response<List<BHEEnt>>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<List<BHEEnt>>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<byte[]> ObtenerPDFBHERecibidosAsync(BHERequest request)
        {
            var url = "/bhe/pdfReceived";
            return await PostForByteArrayAsync<BHERequest>(url, request);
        }
        public async Task<Response<List<BHEEnt>>?> ListadoBHERecibidosAsync(ListaBHERequest request)
        {
            var url = "/bhesReceived";
            var result = await PostAsync<ListaBHERequest, Response<List<BHEEnt>>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<List<BHEEnt>>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
    }
}
