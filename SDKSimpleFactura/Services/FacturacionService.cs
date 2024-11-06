using Newtonsoft.Json;
using SDKSimpleFactura.Models;
using SDKSimpleFactura.Models.Facturacion;
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
        public async Task<byte[]> ObtenerSobreXmlDteAsync(SolicitudDte solicitud)
        {
            var url = "/dte/xml/sobre/0";
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
        public async Task<Response<InvoiceData>> FacturacionIndividualV2DTE(RequestDTE request)
        {
            var url = "/invoiceV2/Casa_Matriz";
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
        public async Task<Response<InvoiceData>> FacturacionIndividualV2Exportacion(RequestDTE request)
        {
            var url = "/dte/exportacion/Casa Matriz";
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
    }
}
