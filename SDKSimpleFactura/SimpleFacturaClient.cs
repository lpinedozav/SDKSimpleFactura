using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Services;
using System.Net.Http.Headers;
using System.Text;

namespace SDKSimpleFactura
{
    public class SimpleFacturaClient
    {
        private readonly HttpClient _httpClient;
        private readonly IApiService _apiService;
        private readonly string baseUrl;
        public IFacturacionService Facturacion { get; }
        public IProductosService Productos { get; }
        public IProveedoresService Proveedores { get; }
        public IClientesService Clientes { get; }
        public ISucursalService Sucursal { get; }
        public IFolioService Folio { get; }
        public IConfiguracionService Configuracion { get; }
        public IBoletasHonorariosService BoletasHonorariosService { get; }

        public SimpleFacturaClient(string username, string password)
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
            _apiService = new ApiService(_httpClient);
            Facturacion = new FacturacionService(_apiService);
            Productos = new ProductosService(_apiService);
            Proveedores = new ProveedoresService(_apiService);
            Clientes = new ClientesService(_apiService);
            Sucursal = new SucursalService(_apiService);
            Folio = new FolioService(_apiService);
            Configuracion = new ConfiguracionService(_apiService);
            BoletasHonorariosService = new BoletasHonorariosService(_apiService);
        }
    }
}
