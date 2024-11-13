using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models;

namespace SDKSimpleFactura.Interfaces
{
    public interface IConfiguracionService
    {
        Task<Response<EmisorApiEnt>?> DatosEmpresaAsync(Credenciales credenciales);
    }
}
