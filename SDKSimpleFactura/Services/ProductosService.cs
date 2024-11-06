using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SDKSimpleFactura.Services
{
    public class ProductosService
    {
        public readonly HttpClient _httpClient;
        public ProductosService(HttpClient httpClient) 
        {
            _httpClient = httpClient;

        }
    }
}
