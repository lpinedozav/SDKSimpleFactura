using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Models.Request;
using SDKSimpleFactura.Models.Response;
using System.Threading.Tasks;

namespace SDKSimpleFactura.Services
{
    public class PartnersService : IPartnersService
    {
        private readonly IApiService _apiService;

        public PartnersService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<Response<PartnerDteResumenEnt>?> ObtenerResumenDtesAsync(PartnerDteResumenRequest request)
        {
            var url = "/partners/dtes/resumen";
            var result = await _apiService.PostAsync<PartnerDteResumenRequest, Response<PartnerDteResumenEnt>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<PartnerDteResumenEnt>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<string>?> EnrolamientoEmpresaAsync(WizardEmisorRequest request)
        {
            var url = "/partners/enrolamiento-empresa";
            var result = await _apiService.PostAsync<WizardEmisorRequest, Response<string>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<string>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
    }
}
