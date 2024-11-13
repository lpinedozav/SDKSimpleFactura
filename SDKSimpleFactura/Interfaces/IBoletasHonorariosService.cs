using SDKSimpleFactura.Models.BoletasHonorarios;
using SDKSimpleFactura.Models;

namespace SDKSimpleFactura.Interfaces
{
    public interface IBoletasHonorariosService
    {
        Task<Response<byte[]>> ObtenerPDFBHEEmitidaAsync(BHERequest request);
        Task<Response<List<BHEEnt>>?> ListadoBHEEmitidasAsync(ListaBHERequest request);
        Task<Response<byte[]>> ObtenerPDFBHERecibidosAsync(BHERequest request);
        Task<Response<List<BHEEnt>>?> ListadoBHERecibidosAsync(ListaBHERequest request);
    }
}
