
namespace SDKSimpleFactura.Services
{
    public class ProveedoresService
    {
        public readonly HttpClient _httpClient;
        public ProveedoresService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }
    }
}
