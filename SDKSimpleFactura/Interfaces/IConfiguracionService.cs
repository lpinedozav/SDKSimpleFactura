using System.Collections.Generic;
using System.Threading.Tasks;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.Request;
using SDKSimpleFactura.Models.Response;

namespace SDKSimpleFactura.Interfaces
{
    public interface IConfiguracionService
    {
        Task<Response<EmisorApiEnt>?> DatosEmpresaAsync(Credenciales credenciales);
        Task<Response<List<ActividadeconomicaApiEnt>>?> ObtenerActividadesEconomicasAsync();
        Task<Response<LastSyncResponse>?> ObtenerUltimaSincronizacionSiiAsync(UltimaSyncRequest request, int mes, int anio);
        Task<TokenExpireEnt?> TiempoExpiracionTokenAsync();
        Task<Response<bool>> SubirCertificadoAsync(CertificadoUploadRequest certificadoData, string pathCertificado);
        Task<Response<bool>> SubirLogoAsync(Credenciales credenciales, string pathLogo);
    }
}
