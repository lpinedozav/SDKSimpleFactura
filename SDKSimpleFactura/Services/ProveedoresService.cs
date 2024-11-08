
using SDKSimpleFactura.Models;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.Proveedores;

namespace SDKSimpleFactura.Services
{
    public class ProveedoresService : BaseService
    {
        public ProveedoresService(HttpClient httpClient) : base(httpClient) { }
        public async Task<Response<bool>> AcuseReciboAsync(AcuseReciboExternoRequest request)
        {
            var url = "/acknowledgmentReceipt";
            return await PostAsync<AcuseReciboExternoRequest, Response<bool>>(url, request);
        }
        public async Task<Response<List<Dte>>> ListadoDtesRecibidosAsync(ListaDteRequest request)
        {
            var url = "/documentsReceived";
            return await PostAsync<ListaDteRequest, Response<List<Dte>>>(url, request);
        }
        public async Task<Response<byte[]>> ObtenerXmlAsync(ListaDteRequest request)
        {
            var url = "/documentReceived/xml";
            return await PostAsync<ListaDteRequest, Response<byte[]>>(url, request);
        }
        public async Task<byte[]> ObtenerPDFAsync(ListaDteRequest request)
        {
            var url = "/documentReceived/getPdf";
            return await PostForByteArrayAsync<ListaDteRequest>(url, request);
        }
        public async Task<Response<string>> ConciliarRecibidosAsync(Credenciales credenciales, int mes, int anio)
        {
            var url = $"/documentsReceived/consolidate/{mes}/{anio}";
            return await PostAsync<Credenciales, Response<string>>(url, credenciales);
        }
    }
}
