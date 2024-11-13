using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKSimpleFactura.Interfaces
{
    public interface IConfiguracionService
    {
        Task<Response<EmisorApiEnt>?> DatosEmpresaAsync(Credenciales credenciales);
    }
}
