using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SDKSimpleFactura.Interfaces
{
    public interface IUsuariosService
    {
        Task<Response<List<UsuarioEnt>?>> ListarUsuariosAsync(Credenciales credenciales);

    }
}
