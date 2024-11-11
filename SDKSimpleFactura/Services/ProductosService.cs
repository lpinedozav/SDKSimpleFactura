using SDKSimpleFactura.Models;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.Folios;
using SDKSimpleFactura.Models.Productos;

namespace SDKSimpleFactura.Services
{
    public class ProductosService : BaseService
    {
        public ProductosService(HttpClient httpClient) : base(httpClient) { }
        public async Task<Response<List<ProductoEnt>>?> AgregarProductosAsync(DatoExternoRequest request)
        {
            var url = "/addProducts";
            var result = await PostAsync<DatoExternoRequest, Response<List<ProductoEnt>>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<List<ProductoEnt>>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<List<ProductoExternoEnt>>?> ListarProductosAsync(Credenciales credenciales)
        {
            var url = "/products";
            var result = await PostAsync<Credenciales, Response<List<ProductoExternoEnt>>>(url, credenciales);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<List<ProductoExternoEnt>>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
    }
}
