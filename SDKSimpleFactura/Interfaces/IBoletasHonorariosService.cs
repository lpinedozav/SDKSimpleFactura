using System.Collections.Generic;
using System.Threading.Tasks;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.Request;
using SDKSimpleFactura.Models.Response;
namespace SDKSimpleFactura.Interfaces
{
    public interface IBoletasHonorariosService
    {
        Task<Response<byte[]>> ObtenerPDFBHEEmitidaAsync(BHERequest request);
        Task<Response<List<BHEEnt>>?> ListadoBHEEmitidasAsync(ListaBHERequest request);
        Task<Response<byte[]>> ObtenerPDFBHERecibidosAsync(BHERequest request);
        Task<Response<List<BHEEnt>>?> ListadoBHERecibidosAsync(ListaBHERequest request);
        Task<Response<BheEmitidaEnt>?> EmitirBheAsync(BHEmitirRequest request);
        Task<Response<BheEmitidaEnt>?> EmitirBheTercerosAsync(BHEmitirRequest request);
        Task<Response<string>?> AnularBheAsync(AnularBheRequest request);
        Task<Response<string>?> ObservarBheAsync(BheObservacionRequest request);
        Task<Response<string>?> ConciliarBheEmitidasAsync(Credenciales credenciales, int mes, int anio);
        Task<Response<string>?> ConciliarBheRecibidasAsync(Credenciales credenciales, int mes, int anio);
    }
}
