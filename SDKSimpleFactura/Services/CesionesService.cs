using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Models.Request;
using SDKSimpleFactura.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SDKSimpleFactura.Services
{
    public class CesionesService : ICesionesService
    {
        private readonly IApiService _apiService;

        public CesionesService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<Response<string>> CederFacturaAsync(CederFacturaRequest request)
        {
            var url = "/cederFactura";
            var result = await _apiService.PostAsync<CederFacturaRequest, Response<string>>(url, request);
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
        public async Task<Response<List<CesionEnt>>?> ListadoCesionesAsync(ListaCesionRequest request)
        {
            var url = "/cessions/Issued";
            var result = await _apiService.PostAsync<ListaCesionRequest, Response<List<CesionEnt>>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<List<CesionEnt>>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<byte[]>> ObtenerXmlCesionAsync(CessionXmlRequest request)
        {
            var url = "/cessions/xml";
            var result = await _apiService.PostForByteArrayAsync<CessionXmlRequest>(url, request);
            if (result.IsSuccess)
            {
                return new Response<byte[]>
                {
                    Status = 200,
                    Data = result.Data
                };
            }
            return new Response<byte[]>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<List<TrazasEnt>>?> GetTrazasCesionesAsync(CesionTrazaRequest request)
        {
            var url = "/cessions/trazasIssued";
            var result = await _apiService.PostAsync<CesionTrazaRequest, Response<List<TrazasEnt>>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<List<TrazasEnt>>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<List<AuthorizedPersonEnt>>?> ListarPersonasAutorizadasAsync(AuthorizedPersonsListRequest request)
        {
            var url = "/cessions/personasAutorizadas";
            var result = await _apiService.PostAsync<AuthorizedPersonsListRequest, Response<List<AuthorizedPersonEnt>>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<List<AuthorizedPersonEnt>>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<AuthorizedPersonEnt>?> AgregarPersonaAutorizadaAsync(AddAuthorizedPersonRequest request)
        {
            var url = "/cessions/personasAutorizadas/agregar";
            var result = await _apiService.PostAsync<AddAuthorizedPersonRequest, Response<AuthorizedPersonEnt>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<AuthorizedPersonEnt>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<List<CessionaryEnt>>?> ListarCesionariosAsync(CessionariesListRequest request)
        {
            var url = "/cessions/cesionarios";
            var result = await _apiService.PostAsync<CessionariesListRequest, Response<List<CessionaryEnt>>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<List<CessionaryEnt>>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
        public async Task<Response<CessionaryEnt>?> AgregarCesionarioAsync(AddCessionaryRequest request)
        {
            var url = "/cessions/cesionarios/agregar";
            var result = await _apiService.PostAsync<AddCessionaryRequest, Response<CessionaryEnt>>(url, request);
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new Response<CessionaryEnt>
            {
                Status = result.StatusCode,
                Message = result.Errores,
                Data = null
            };
        }
    }
}
