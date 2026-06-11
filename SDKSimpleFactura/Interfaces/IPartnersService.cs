using System.Threading.Tasks;
using SDKSimpleFactura.Models.Request;
using SDKSimpleFactura.Models.Response;

namespace SDKSimpleFactura.Interfaces
{
    public interface IPartnersService
    {
        Task<Response<PartnerDteResumenEnt>?> ObtenerResumenDtesAsync(PartnerDteResumenRequest request);
        Task<Response<string>?> EnrolamientoEmpresaAsync(WizardEmisorRequest request);
    }
}
