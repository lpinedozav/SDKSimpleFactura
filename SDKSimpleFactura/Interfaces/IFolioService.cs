using System.Collections.Generic;
using System.Threading.Tasks;
using SDKSimpleFactura.Models.Request;
using SDKSimpleFactura.Models.Response;

namespace SDKSimpleFactura.Interfaces
{
    public interface IFolioService
    {
        Task<Response<int>?> ConsultaFoliosDisponiblesAsync(SolicitudFoliosRequest request);
        Task<Response<TimbrajeApiEnt>?> SolicitarFoliosAsync(FolioRequest request);
        Task<Response<List<TimbrajeApiEnt>>?> ConsultarFoliosAsync(FolioRequest request);
        Task<Response<List<FoliosAnulablesEnt>>?> FoliosSinUsoAsync(SolicitudFoliosRequest request);
    }
}
