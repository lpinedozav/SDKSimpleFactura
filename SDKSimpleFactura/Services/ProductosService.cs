using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.Productos;
using SDKSimpleFactura.Models.Request;
using SDKSimpleFactura.Models.Response;

namespace SDKSimpleFactura.Services
{
    public class ProductosService : IProductosService
    {
        private readonly IApiService _apiService;
        public ProductosService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<Response<List<ProductoEnt>>?> AgregarProductosAsync(DatoExternoRequest request)
        {
            var url = "/addProducts";
            var result = await _apiService.PostAsync<DatoExternoRequest, Response<List<ProductoEnt>>>(url, request);
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
            var result = await _apiService.PostAsync<Credenciales, Response<List<ProductoExternoEnt>>>(url, credenciales);
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
