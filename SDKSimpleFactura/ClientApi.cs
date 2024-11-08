using SDKSimpleFactura.Services;
using System.Net.Http.Headers;
using System.Text;

namespace SDKSimpleFactura
{
    public class ClientApi
    {
        public readonly HttpClient _httpClient;
        public readonly string baseUrl;
        public FacturacionService Facturacion { get; }
        public ProductosService Productos { get; }

        public ClientApi(string username, string password)
        {
            baseUrl = "https://api.simplefactura.cl";
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };

            // Configurar autenticación básica
            var authToken = Encoding.ASCII.GetBytes($"{username}:{password}");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Facturacion = new FacturacionService(_httpClient);
            Productos = new ProductosService(_httpClient);
        }
    }
}
