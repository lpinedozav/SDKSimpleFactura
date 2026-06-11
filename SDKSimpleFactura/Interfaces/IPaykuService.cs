using System.Collections.Generic;
using System.Threading.Tasks;
using SDKSimpleFactura.Models.Request;
using SDKSimpleFactura.Models.Response;

namespace SDKSimpleFactura.Interfaces
{
    public interface IPaykuService
    {
        Task<Response<List<PaykuTransaccionEnt>>?> TransaccionesAsync(PaykuTransaccionesRequest request);
        Task<Response<bool>?> ActivarDesactivarAsync(PaykuToggleRequest request);
        Task<Response<string>?> GenerarUrlAsync(PaykuReenviarLinkRequest request);
        Task<Response<bool>?> ReenviarLinkQrAsync(PaykuReenviarLinkRequest request);
    }
}
