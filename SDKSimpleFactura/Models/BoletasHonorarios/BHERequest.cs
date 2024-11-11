using SDKSimpleFactura.Models.Facturacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKSimpleFactura.Models.BoletasHonorarios
{
    public class BHERequest
    {
        public Credenciales Credenciales { get; set; }
        public int Folio { get; set; }

    }
}
