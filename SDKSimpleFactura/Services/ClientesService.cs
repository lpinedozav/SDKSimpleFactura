
namespace SDKSimpleFactura.Services
{
    public class ClientesService
    {
        public readonly HttpClient _httpClient;
        public ClientesService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }
    }
}
