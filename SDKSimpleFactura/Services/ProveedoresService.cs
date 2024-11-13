
using SDKSimpleFactura.Models;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Models.Proveedores;

namespace SDKSimpleFactura.Services
{
    public class ProveedoresService : IProveedoresService
    {
        private readonly IApiService _apiService;
        public ProveedoresService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<Response<bool>?> AcuseReciboAsync(AcuseReciboExternoRequest request)
        {
            var url = "/acknowledgmentReceipt";
            var result = await _apiService.PostAsync<AcuseReciboExternoRequest, Response<bool>>(url, request);
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
        public async Task<Response<List<Dte>>?> ListadoDtesRecibidosAsync(ListaDteRequest request)
        {
            var url = "/documentsReceived";
            var result = await _apiService.PostAsync<ListaDteRequest, Response<List<Dte>>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<List<Dte>>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<byte[]>?> ObtenerXmlAsync(ListaDteRequest request)
        {
            var url = "/documentReceived/xml";
            var result = await _apiService.PostAsync<ListaDteRequest, Response<byte[]>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<byte[]>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<byte[]>> ObtenerPDFAsync(ListaDteRequest request)
        {
            var url = "/documentReceived/getPdf";
            var result = await _apiService.PostForByteArrayAsync<ListaDteRequest>(url, request);
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
        public async Task<Response<string>?> ConciliarRecibidosAsync(Credenciales credenciales, int mes, int anio)
        {
            var url = $"/documentsReceived/consolidate/{mes}/{anio}";
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
