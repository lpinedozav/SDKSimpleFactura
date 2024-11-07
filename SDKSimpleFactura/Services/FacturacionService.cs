using Newtonsoft.Json;
using SDKSimpleFactura.Enum;
using SDKSimpleFactura.Models;
using SDKSimpleFactura.Models.Facturacion;
using System.Net.Http.Headers;
using System.Text;

namespace SDKSimpleFactura.Services
{
    public class FacturacionService
    {
        public readonly HttpClient _httpClient;

        public FacturacionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<byte[]> ObtenerPdfDteAsync(SolicitudDte solicitud)
        {
            var url = "/dte/pdf";

            // Serializar la solicitud a JSON
            var jsonSolicitud = JsonConvert.SerializeObject(solicitud);
            var contenido = new StringContent(jsonSolicitud, Encoding.UTF8, "application/json");

            // Hacer la solicitud POST
            var respuesta = await _httpClient.PostAsync(url, contenido);

            // Verificar si la respuesta es exitosa
            if (respuesta.IsSuccessStatusCode)
            {
                // Leer el contenido de la respuesta como bytes
                var pdfBytes = await respuesta.Content.ReadAsByteArrayAsync();
                return pdfBytes;
            }
            else
            {
                // Leer el contenido de la respuesta de error
                var contenidoError = await respuesta.Content.ReadAsStringAsync();
                // Opcional: Deserializar el error si la API devuelve un objeto JSON
                // var error = JsonConvert.DeserializeObject<ErrorApi>(contenidoError);
                throw new Exception($"Error en la petición: {contenidoError}");
            }
        }
        public async Task<Response<string>> ObtenerTimbreDteAsync(SolicitudDte solicitud)
        {
            var url = "/dte/timbre";
            var jsonSolicitud = JsonConvert.SerializeObject(solicitud);
            var contenido = new StringContent(jsonSolicitud, Encoding.UTF8, "application/json");
            var respuesta = await _httpClient.PostAsync(url, contenido);
            var contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();
            if (respuesta.IsSuccessStatusCode)
            {
                // Leer el contenido de la respuesta como bytes
                var resultado = JsonConvert.DeserializeObject<Response<string>>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error en la petición: {contenidoRespuesta}");
            }
        }
        public async Task<byte[]> ObtenerXmlDteAsync(SolicitudDte solicitud)
        {
            var url = "/dte/xml";
            var jsonSolicitud = JsonConvert.SerializeObject(solicitud);
            var contenido = new StringContent(jsonSolicitud, Encoding.UTF8, "application/json");
            var respuesta = await _httpClient.PostAsync(url, contenido);
            if (respuesta.IsSuccessStatusCode)
            {
                // Leer el contenido de la respuesta como bytes
                var xmlBytes = await respuesta.Content.ReadAsByteArrayAsync();
                return xmlBytes;
            }
            else
            {
                // Leer el contenido de la respuesta de error
                var contenidoError = await respuesta.Content.ReadAsStringAsync();
                // Opcional: Deserializar el error si la API devuelve un objeto JSON
                // var error = JsonConvert.DeserializeObject<ErrorApi>(contenidoError);
                throw new Exception($"Error en la petición: {contenidoError}");
            }

        }
        public async Task<Response<Dte>> ObtenerDteAsync(SolicitudDte solicitud)
        {
            var url = "/documentIssued";
            var jsonSolicitud = JsonConvert.SerializeObject(solicitud);
            var contenido = new StringContent(jsonSolicitud, Encoding.UTF8, "application/json");

            var respuesta = await _httpClient.PostAsync(url, contenido);

            var contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();

            if (respuesta.IsSuccessStatusCode)
            {
                var resultado = JsonConvert.DeserializeObject<Response<Dte>>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error en la petición: {contenidoRespuesta}");
            }
        }
        public async Task<byte[]> ObtenerSobreXmlDteAsync(SolicitudDte solicitud, TipoSobreEnvio tipoSobre)
        {
            var url = $"/dte/xml/sobre/{tipoSobre}";
            var jsonSolicitud = JsonConvert.SerializeObject(solicitud);
            var contenido = new StringContent(jsonSolicitud, Encoding.UTF8, "application/json");
            var respuesta = await _httpClient.PostAsync(url, contenido);
            if (respuesta.IsSuccessStatusCode)
            {
                // Leer el contenido de la respuesta como bytes
                var xmlBytes = await respuesta.Content.ReadAsByteArrayAsync();
                return xmlBytes;
            }
            else
            {
                // Leer el contenido de la respuesta de error
                var contenidoError = await respuesta.Content.ReadAsStringAsync();
                // Opcional: Deserializar el error si la API devuelve un objeto JSON
                // var error = JsonConvert.DeserializeObject<ErrorApi>(contenidoError);
                throw new Exception($"Error en la petición: {contenidoError}");
            }

        }
        public async Task<Response<InvoiceData>> FacturacionIndividualV2DTEAsync(string sucursal, RequestDTE request)
        {
            var url = $"/invoiceV2/{sucursal}";
            var jsonSolicitud = JsonConvert.SerializeObject(request);
            var contenido = new StringContent(jsonSolicitud, Encoding.UTF8, "application/json");

            var respuesta = await _httpClient.PostAsync(url, contenido);

            var contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();

            if (respuesta.IsSuccessStatusCode)
            {
                var resultado = JsonConvert.DeserializeObject<Response<InvoiceData>>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error en la petición: {contenidoRespuesta}");
            }
        }
        public async Task<Response<InvoiceData>> FacturacionIndividualV2ExportacionAsync(string sucursal, RequestDTE request)
        {
            var url = $"/dte/exportacion/{sucursal}";
            var jsonSolicitud = JsonConvert.SerializeObject(request);
            var contenido = new StringContent(jsonSolicitud, Encoding.UTF8, "application/json");

            var respuesta = await _httpClient.PostAsync(url, contenido);

            var contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();

            if (respuesta.IsSuccessStatusCode)
            {
                var resultado = JsonConvert.DeserializeObject<Response<InvoiceData>>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error en la petición: {contenidoRespuesta}");
            }
        }
        public async Task<Response<bool>> FacturacionMasivaAsync(Credenciales credenciales, string pathCsv)
        {
            var url = "/massiveInvoice";
            // Crear el contenido multipart/form-data
            using (var contenido = new MultipartFormDataContent())
            {
                // Agregar las credenciales como campo JSON
                var jsonCredenciales = JsonConvert.SerializeObject(credenciales);
                var contenidoCredenciales = new StringContent(jsonCredenciales, Encoding.UTF8, "application/json");
                contenido.Add(contenidoCredenciales, "data");

                // Agregar el archivo CSV
                using (var stream = File.OpenRead(pathCsv))
                {
                    var contenidoArchivo = new StreamContent(stream);
                    contenidoArchivo.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
                    contenido.Add(contenidoArchivo, "input", Path.GetFileName(pathCsv));

                    // Enviar la solicitud
                    var respuesta = await _httpClient.PostAsync(url, contenido);

                    var contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();

                    if (respuesta.IsSuccessStatusCode)
                    {
                        var resultado = JsonConvert.DeserializeObject<Response<bool>>(contenidoRespuesta);
                        return resultado;
                    }
                    else
                    {
                        throw new Exception($"Error en la petición: {contenidoRespuesta}");
                    }
                }
            }
        }
        public async Task<Response<InvoiceData>> EmisionNC_NDV2Async(string sucursal, ReasonTypeEnum motivo, RequestDTE request)
        {
            var url = $"/invoiceCreditDebitNotesV2/{sucursal}/{motivo}";
            var jsonSolicitud = JsonConvert.SerializeObject(request);
            var contenido = new StringContent(jsonSolicitud, Encoding.UTF8, "application/json");

            var respuesta = await _httpClient.PostAsync(url, contenido);

            var contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();

            if (respuesta.IsSuccessStatusCode)
            {
                var resultado = JsonConvert.DeserializeObject<Response<InvoiceData>>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error en la petición: {contenidoRespuesta}");
            }
        }
        public async Task<Response<List<Dte>>> ListadoDtesEmitidosAsync(ListaDteRequest request)
        {
            var url = "/documentsIssued";
            var jsonSolicitud = JsonConvert.SerializeObject(request);
            var contenido = new StringContent(jsonSolicitud, Encoding.UTF8, "application/json");

            var respuesta = await _httpClient.PostAsync(url, contenido);

            var contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();

            if (respuesta.IsSuccessStatusCode)
            {
                var resultado = JsonConvert.DeserializeObject<Response<List<Dte>>>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error en la petición: {contenidoRespuesta}");
            }
        }
        public async Task<Response<bool>> EnvioMailAsync(EnvioMailRequest request)
        {
            var url = "/dte/enviar/mail";
            var jsonSolicitud = JsonConvert.SerializeObject(request);
            var contenido = new StringContent(jsonSolicitud, Encoding.UTF8, "application/json");

            var respuesta = await _httpClient.PostAsync(url, contenido);

            var contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();

            if (respuesta.IsSuccessStatusCode)
            {
                var resultado = JsonConvert.DeserializeObject<Response<bool>>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error en la petición: {contenidoRespuesta}");
            }
        }
        public async Task<Response<List<ReporteDTE>>> ConsolidadoVentas(ListaDteRequest request)
        {
            var url = "/dte/consolidated/issued";
            var jsonSolicitud = JsonConvert.SerializeObject(request);
            var contenido = new StringContent(jsonSolicitud, Encoding.UTF8, "application/json");

            var respuesta = await _httpClient.PostAsync(url, contenido);

            var contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();

            if (respuesta.IsSuccessStatusCode)
            {
                var resultado = JsonConvert.DeserializeObject<Response<List<ReporteDTE>>>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error en la petición: {contenidoRespuesta}");
            }
        }
        public async Task<Response<string>> ConsolidadoEmitidos(Credenciales credenciales, int mes, int anio)
        {
            var url = $"/documentsIssued/consolidate/{mes}/{anio}";
            var jsonSolicitud = JsonConvert.SerializeObject(credenciales);
            var contenido = new StringContent(jsonSolicitud, Encoding.UTF8, "application/json");

            var respuesta = await _httpClient.PostAsync(url, contenido);

            var contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();

            if (respuesta.IsSuccessStatusCode)
            {
                var resultado = JsonConvert.DeserializeObject<Response<string>>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error en la petición: {contenidoRespuesta}");
            }
        }
    }
}
