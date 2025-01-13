using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SDKSimpleFactura.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IApiService _apiService;
        public UsuariosService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<Response<List<UsuarioEnt>?>> ListarUsuariosAsync(Credenciales credenciales)
        {
            var url = "/empresas/usuarios";
            var result = await _apiService.PostAsync<Credenciales, Response<List<UsuarioEnt>>>(url, credenciales);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<List<UsuarioEnt>?>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
    }
}
