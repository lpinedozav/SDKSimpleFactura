using System.Collections.Generic;
using System.Threading.Tasks;
using SDKSimpleFactura.Models.Request;
using SDKSimpleFactura.Models.Response;

namespace SDKSimpleFactura.Interfaces
{
    public interface ICesionesService
    {
        Task<Response<string>> CederFacturaAsync(CederFacturaRequest request);
        Task<Response<List<CesionEnt>>?> ListadoCesionesAsync(ListaCesionRequest request);
        Task<Response<byte[]>> ObtenerXmlCesionAsync(CessionXmlRequest request);
        Task<Response<List<TrazasEnt>>?> GetTrazasCesionesAsync(CesionTrazaRequest request);
        Task<Response<List<AuthorizedPersonEnt>>?> ListarPersonasAutorizadasAsync(AuthorizedPersonsListRequest request);
        Task<Response<AuthorizedPersonEnt>?> AgregarPersonaAutorizadaAsync(AddAuthorizedPersonRequest request);
        Task<Response<List<CessionaryEnt>>?> ListarCesionariosAsync(CessionariesListRequest request);
        Task<Response<CessionaryEnt>?> AgregarCesionarioAsync(AddCessionaryRequest request);
    }
}
