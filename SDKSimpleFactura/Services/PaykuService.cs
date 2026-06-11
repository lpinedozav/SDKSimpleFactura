using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Models.Request;
using SDKSimpleFactura.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SDKSimpleFactura.Services
{
    public class PaykuService : IPaykuService
    {
        private readonly IApiService _apiService;

        public PaykuService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<Response<List<PaykuTransaccionEnt>>?> TransaccionesAsync(PaykuTransaccionesRequest request)
        {
            var url = "/payku/transacciones";
            var result = await _apiService.PostAsync<PaykuTransaccionesRequest, Response<List<PaykuTransaccionEnt>>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<List<PaykuTransaccionEnt>>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<bool>?> ActivarDesactivarAsync(PaykuToggleRequest request)
        {
            var url = "/payku/activar-desactivar";
            var result = await _apiService.PostAsync<PaykuToggleRequest, Response<bool>>(url, request);
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
        public async Task<Response<string>?> GenerarUrlAsync(PaykuReenviarLinkRequest request)
        {
            var url = "/payku/generar-url";
            var result = await _apiService.PostAsync<PaykuReenviarLinkRequest, Response<string>>(url, request);
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
        public async Task<Response<bool>?> ReenviarLinkQrAsync(PaykuReenviarLinkRequest request)
        {
            var url = "/payku/reenviar-link-Qr";
            var result = await _apiService.PostAsync<PaykuReenviarLinkRequest, Response<bool>>(url, request);
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
