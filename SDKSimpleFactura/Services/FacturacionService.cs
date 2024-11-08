using Newtonsoft.Json;
using SDKSimpleFactura.Enum;
using SDKSimpleFactura.Models;
using SDKSimpleFactura.Models.Facturacion;
using System.Net.Http.Headers;
using System.Text;

namespace SDKSimpleFactura.Services
{
    public class FacturacionService : BaseService
    {
        public FacturacionService(HttpClient httpClient) : base(httpClient) { }
        public async Task<byte[]> ObtenerPdfDteAsync(SolicitudDte solicitud)
        {
            var url = "/dte/pdf";
            return await PostForByteArrayAsync<SolicitudDte>(url, solicitud);
        }
        public async Task<Response<string>> ObtenerTimbreDteAsync(SolicitudDte solicitud)
        {
            var url = "/dte/timbre";
            return await PostAsync<SolicitudDte, Response<string>>(url, solicitud);
        }
        public async Task<byte[]> ObtenerXmlDteAsync(SolicitudDte solicitud)
        {
            var url = "/dte/xml";
            return await PostForByteArrayAsync<SolicitudDte>(url, solicitud);
        }
        public async Task<Response<Dte>> ObtenerDteAsync(SolicitudDte solicitud)
        {
            var url = "/documentIssued";
            return await PostAsync<SolicitudDte, Response<Dte>>(url, solicitud);
        }
        public async Task<byte[]> ObtenerSobreXmlDteAsync(SolicitudDte solicitud, TipoSobreEnvio tipoSobre)
        {
            var url = $"/dte/xml/sobre/{tipoSobre}";
            return await PostForByteArrayAsync<SolicitudDte>(url, solicitud);

        }
        public async Task<Response<InvoiceData>> FacturacionIndividualV2DTEAsync(string sucursal, RequestDTE request)
        {
            var url = $"/invoiceV2/{sucursal}";
            return await PostAsync<RequestDTE, Response<InvoiceData>>(url, request);
        }
        public async Task<Response<InvoiceData>> FacturacionIndividualV2ExportacionAsync(string sucursal, RequestDTE request)
        {
            var url = $"/dte/exportacion/{sucursal}";
            return await PostAsync<RequestDTE, Response<InvoiceData>>(url, request);

        }
        public async Task<Response<bool>> FacturacionMasivaAsync(Credenciales credenciales, string pathCsv)
        {
            var url = "/massiveInvoice";
            using (var content = new MultipartFormDataContent())
            {
                var jsonCredenciales = JsonConvert.SerializeObject(credenciales);
                var credencialesContent = new StringContent(jsonCredenciales, Encoding.UTF8, "application/json");
                content.Add(credencialesContent, "data");

                using (var stream = File.OpenRead(pathCsv))
                {
                    var fileContent = new StreamContent(stream);
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
                    content.Add(fileContent, "input", Path.GetFileName(pathCsv));

                    return await PostMultipartAsync<Response<bool>>(url, content);
                }
            }
        }
        public async Task<Response<InvoiceData>> EmisionNC_NDV2Async(string sucursal, ReasonTypeEnum motivo, RequestDTE request)
        {
            var url = $"/invoiceCreditDebitNotesV2/{sucursal}/{motivo}";
            return await PostAsync<RequestDTE, Response<InvoiceData>>(url, request);
        }
        public async Task<Response<List<Dte>>> ListadoDtesEmitidosAsync(ListaDteRequest request)
        {
            var url = "/documentsIssued";
            return await PostAsync<ListaDteRequest, Response<List<Dte>>>(url,request);
        }
        public async Task<Response<bool>> EnvioMailAsync(EnvioMailRequest request)
        {
            var url = "/dte/enviar/mail";
            return await PostAsync<EnvioMailRequest, Response<bool>>(url,request);
        }
        public async Task<Response<List<ReporteDTE>>> ConsolidadoVentas(ListaDteRequest request)
        {
            var url = "/dte/consolidated/issued";
            return await PostAsync<ListaDteRequest, Response<List<ReporteDTE>>>(url, request);
        }
        public async Task<Response<string>> ConsolidadoEmitidos(Credenciales credenciales, int mes, int anio)
        {
            var url = $"/documentsIssued/consolidate/{mes}/{anio}";
            return await PostAsync<Credenciales, Response<string>>(url, credenciales);
        }
    }
}
