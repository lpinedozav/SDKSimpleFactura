using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.Request;
using SDKSimpleFactura.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<Response<BheEmitidaEnt>?> EmitirBheAsync(BHEmitirRequest request)
        {
            var url = "/bhe/emitir";
            var result = await _apiService.PostAsync<BHEmitirRequest, Response<BheEmitidaEnt>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<BheEmitidaEnt>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<BheEmitidaEnt>?> EmitirBheTercerosAsync(BHEmitirRequest request)
        {
            var url = "/bhe/terceros/emitir";
            var result = await _apiService.PostAsync<BHEmitirRequest, Response<BheEmitidaEnt>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<BheEmitidaEnt>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<string>?> AnularBheAsync(AnularBheRequest request)
        {
            var url = "/bhe/anular";
            var result = await _apiService.PostAsync<AnularBheRequest, Response<string>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<string>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<string>?> ObservarBheAsync(BheObservacionRequest request)
        {
            var url = "/bhe/observacion";
            var result = await _apiService.PostAsync<BheObservacionRequest, Response<string>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<string>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<string>?> ConciliarBheEmitidasAsync(Credenciales credenciales, int mes, int anio)
        {
            var url = $"/bhesIssued/consolidate/{mes}/{anio}";
            var result = await _apiService.PostAsync<Credenciales, Response<string>>(url, credenciales);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<string>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<string>?> ConciliarBheRecibidasAsync(Credenciales credenciales, int mes, int anio)
        {
            var url = $"/bhesReceived/consolidate/{mes}/{anio}";
            var result = await _apiService.PostAsync<Credenciales, Response<string>>(url, credenciales);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<string>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
    }
}
