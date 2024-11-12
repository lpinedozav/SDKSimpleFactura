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
        public async Task<Response<byte[]>> ObtenerPdfDteAsync(SolicitudDte solicitud)
        {
            var url = "/dte/pdf";
            var result = await PostForByteArrayAsync<SolicitudDte>(url, solicitud);
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
        public async Task<Response<string>?> ObtenerTimbreDteAsync(SolicitudDte solicitud)
        {
            var url = "/dte/timbre";
            var result = await PostAsync<SolicitudDte, Response<string>>(url, solicitud);
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
        public async Task<Response<byte[]>> ObtenerXmlDteAsync(SolicitudDte solicitud)
        {
            var url = "/dte/xml";
            var result = await PostForByteArrayAsync<SolicitudDte>(url, solicitud);
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
        public async Task<Response<Dte>?> ObtenerDteAsync(SolicitudDte solicitud)
        {
            var url = "/documentIssued";
            var result = await PostAsync<SolicitudDte, Response<Dte>>(url, solicitud);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<Dte>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<byte[]>> ObtenerSobreXmlDteAsync(SolicitudDte solicitud, TipoSobreEnvio tipoSobre)
        {
            var url = $"/dte/xml/sobre/{tipoSobre}";
            var result = await PostForByteArrayAsync<SolicitudDte>(url, solicitud);
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
        public async Task<Response<InvoiceData>?> FacturacionIndividualV2DTEAsync(string sucursal, RequestDTE request)
        {
            var url = $"/invoiceV2/{sucursal}";
            var result = await PostAsync<RequestDTE, Response<InvoiceData>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<InvoiceData>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<InvoiceData>?> FacturacionIndividualV2ExportacionAsync(string sucursal, RequestDTE request)
        {
            var url = $"/dte/exportacion/{sucursal}";
            var result = await PostAsync<RequestDTE, Response<InvoiceData>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<InvoiceData>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
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

                    var result = await PostMultipartAsync<Response<bool>>(url, content);
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
        public async Task<Response<InvoiceData>?> EmisionNC_NDV2Async(string sucursal, ReasonTypeEnum motivo, RequestDTE request)
        {
            var url = $"/invoiceCreditDebitNotesV2/{sucursal}/{motivo}";
            var result = await PostAsync<RequestDTE, Response<InvoiceData>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<InvoiceData>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<List<Dte>>?> ListadoDtesEmitidosAsync(ListaDteRequest request)
        {
            var url = "/documentsIssued";
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
        public async Task<Response<bool>?> EnvioMailAsync(EnvioMailRequest request)
        {
            var url = "/dte/enviar/mail";
            var result = await PostAsync<EnvioMailRequest, Response<bool>>(url, request);
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
        public async Task<Response<List<ReporteDTE>>?> ConsolidadoVentasAsync(ListaDteRequest request)
        {
            var url = "/dte/consolidated/issued";
            var result = await PostAsync<ListaDteRequest, Response<List<ReporteDTE>>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<List<ReporteDTE>>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<string>?> ConsolidadoEmitidosAsync(Credenciales credenciales, int mes, int anio)
        {
            var url = $"/documentsIssued/consolidate/{mes}/{anio}";
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
