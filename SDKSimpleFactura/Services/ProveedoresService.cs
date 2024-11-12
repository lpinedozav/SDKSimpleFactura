
using SDKSimpleFactura.Models;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.Productos;
using SDKSimpleFactura.Models.Proveedores;

namespace SDKSimpleFactura.Services
{
    public class ProveedoresService : BaseService
    {
        public ProveedoresService(HttpClient httpClient) : base(httpClient) { }
        public async Task<Response<bool>?> AcuseReciboAsync(AcuseReciboExternoRequest request)
        {
            var url = "/acknowledgmentReceipt";
            var result = await PostAsync<AcuseReciboExternoRequest, Response<bool>>(url, request);
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
            var result = await PostAsync<ListaDteRequest, Response<List<Dte>>>(url, request);
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
            var result = await PostAsync<ListaDteRequest, Response<byte[]>>(url, request);
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
            var result = await PostForByteArrayAsync<ListaDteRequest>(url, request);
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
            var result = await PostAsync<Credenciales, Response<string>>(url, credenciales);
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
