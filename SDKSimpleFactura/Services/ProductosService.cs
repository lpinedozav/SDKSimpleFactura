using SDKSimpleFactura.Models;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.Productos;

namespace SDKSimpleFactura.Services
{
    public class ProductosService : BaseService
    {
        public ProductosService(HttpClient httpClient) : base(httpClient) { }
        public async Task<Response<List<ProductoEnt>>> AgregarProductosAsync(DatoExternoRequest request)
        {
            var url = "/addProducts";
            return await PostAsync<DatoExternoRequest, Response<List<ProductoEnt>>>(url, request);
        }
        public async Task<Response<List<ProductoExternoEnt>>> ListarProductosAsync(Credenciales credenciales)
        {
            var url = "/products";
            return await PostAsync<Credenciales, Response<List<ProductoExternoEnt>>>(url, credenciales);
        }
    }
}
