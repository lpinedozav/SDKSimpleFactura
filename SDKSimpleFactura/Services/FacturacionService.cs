using Newtonsoft.Json;
using SDKSimpleFactura.Enum;
using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.Request;
using SDKSimpleFactura.Models.Response;
using System.Net.Http.Headers;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
namespace SDKSimpleFactura.Services
{
    public class FacturacionService : IFacturacionService
    {
        private readonly IApiService _apiService;

        public FacturacionService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<Response<byte[]>> ObtenerPdfDteAsync(SolicitudDte solicitud)
        {
            var url = "/dte/pdf";
            var result = await _apiService.PostForByteArrayAsync<SolicitudDte>(url, solicitud);
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
            var result = await _apiService.PostAsync<SolicitudDte, Response<string>>(url, solicitud);
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
            var result = await _apiService.PostForByteArrayAsync<SolicitudDte>(url, solicitud);
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
        public async Task<Response<DteEnt>?> ObtenerDteAsync(SolicitudDte solicitud)
        {
            var url = "/documentIssued";
            var result = await _apiService.PostAsync<SolicitudDte, Response<DteEnt>>(url, solicitud);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<DteEnt>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<byte[]>> ObtenerSobreXmlDteAsync(SolicitudDte solicitud, TipoSobreEnvio tipoSobre)
        {
            var url = $"/dte/xml/sobre/{tipoSobre}";
            var result = await _apiService.PostForByteArrayAsync<SolicitudDte>(url, solicitud);
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
            var result = await _apiService.PostAsync<RequestDTE, Response<InvoiceData>>(url, request);
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
            var result = await _apiService.PostAsync<RequestDTE, Response<InvoiceData>>(url, request);
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

                    var result = await _apiService.PostMultipartAsync<Response<bool>>(url, content);
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
            var result = await _apiService.PostAsync<RequestDTE, Response<InvoiceData>>(url, request);
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
        public async Task<Response<List<DteEnt>>?> ListadoDtesEmitidosAsync(ListaDteRequest request)
        {
            var url = "/documentsIssued";
            var result = await _apiService.PostAsync<ListaDteRequest, Response<List<DteEnt>>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<List<DteEnt>>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<bool>?> EnvioMailAsync(EnvioMailRequest request)
        {
            var url = "/dte/enviar/mail";
            var result = await _apiService.PostAsync<EnvioMailRequest, Response<bool>>(url, request);
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
            var result = await _apiService.PostAsync<ListaDteRequest, Response<List<ReporteDTE>>>(url, request);
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
        public async Task<Response<string>?> ConciliarEmitidosAsync(Credenciales credenciales, int mes, int anio)
        {
            var url = $"/documentsIssued/consolidate/{mes}/{anio}";
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
        public async Task<Response<List<TrazasEnt>>> GetTrazasEmitidosAsync(SolicitudDte request)
        {
            var url = $"/dte/trazasIssued";
            var result = await _apiService.PostAsync<SolicitudDte,Response<List<TrazasEnt>>>(url,request);
            if ( result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<List<TrazasEnt>>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
    }
}
