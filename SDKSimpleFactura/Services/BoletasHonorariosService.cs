using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Models.BoletasHonorarios;
using SDKSimpleFactura.Models.Request;
using SDKSimpleFactura.Models.Response;

namespace SDKSimpleFactura.Services
{
    public class BoletasHonorariosService : IBoletasHonorariosService
    {
        private readonly IApiService _apiService;
        public BoletasHonorariosService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<Response<byte[]>> ObtenerPDFBHEEmitidaAsync(BHERequest request)
        {
            var url = "/bhe/pdfIssuied";
            var result = await _apiService.PostForByteArrayAsync<BHERequest> (url, request);
            if (result.IsSuccess)
            {
                return new Response<byte[]>
                {
                    Status = 200,
                    Data = result.Data
                };
            }
            return new Response<byte[]>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<List<BHEEnt>>?> ListadoBHEEmitidasAsync(ListaBHERequest request)
        {
            var url = "/bhesIssued";
            var result = await _apiService.PostAsync<ListaBHERequest, Response<List<BHEEnt>>>(url, request);
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
        public async Task<Response<byte[]>> ObtenerPDFBHERecibidosAsync(BHERequest request)
        {
            var url = "/bhe/pdfReceived";
            var result = await _apiService.PostForByteArrayAsync<BHERequest>(url, request);
            if (result.IsSuccess)
            {
                return new Response<byte[]>
                {
                    Status = 200,
                    Data = result.Data
                };
            }
            return new Response<byte[]>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<List<BHEEnt>>?> ListadoBHERecibidosAsync(ListaBHERequest request)
        {
            var url = "/bhesReceived";
            var result = await _apiService.PostAsync<ListaBHERequest, Response<List<BHEEnt>>>(url, request);
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
