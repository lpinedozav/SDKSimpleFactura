using SDKSimpleFactura.Models.Proveedores;
using SDKSimpleFactura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDKSimpleFactura.Models.Facturacion;

namespace SDKSimpleFactura.Interfaces
{
    public interface IProveedoresService
    {
        Task<Response<bool>?> AcuseReciboAsync(AcuseReciboExternoRequest request);
        Task<Response<List<Dte>>?> ListadoDtesRecibidosAsync(ListaDteRequest request);
        Task<Response<byte[]>?> ObtenerXmlAsync(ListaDteRequest request);
        Task<Response<byte[]>> ObtenerPDFAsync(ListaDteRequest request);
        Task<Response<string>?> ConciliarRecibidosAsync(Credenciales credenciales, int mes, int anio);
    }
}
