using System.Collections.Generic;
using System.Threading.Tasks;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.Request;
using SDKSimpleFactura.Models.Response;

namespace SDKSimpleFactura.Interfaces
{
    public interface IProveedoresService
    {
        Task<Response<bool>?> AcuseReciboAsync(AcuseReciboExternoRequest request);
        Task<Response<List<DteEnt>>?> ListadoDtesRecibidosAsync(ListaDteRequest request);
        Task<Response<byte[]>?> ObtenerXmlAsync(ListaDteRequest request);
        Task<Response<byte[]>> ObtenerPDFAsync(ListaDteRequest request);
        Task<Response<string>?> ConciliarRecibidosAsync(Credenciales credenciales, int mes, int anio);
    }
}
