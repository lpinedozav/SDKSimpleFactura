using System;
using System.Collections.Generic;
using System.Text;

namespace SDKSimpleFactura.Models.Request
{
    public class CederFacturaRequest
    {
        public string CorreoDeudor { get; set; }
        public string RutCesionario { get; set; }
        public string RutPersonaAutorizada { get; set; }
        public string OtrasCondiciones { get; set; }
        public int Folio { get; set; }
        public string RutEmpresa { get; set; }
    }
}
