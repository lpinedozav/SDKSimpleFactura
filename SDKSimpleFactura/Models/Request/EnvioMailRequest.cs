using System.Collections.Generic;
namespace SDKSimpleFactura.Models.Request
{
    public class EnvioMailRequest
    {
        public string RutEmpresa { get; set; }
        public DteClass Dte { get; set; }
        public MailClass Mail { get; set; }
        public bool Xml { get; set; }
        public bool Pdf { get; set; }
        public string? Comments { get; set; }

        public EnvioMailRequest()
        {
            Dte = new DteClass();
            Mail = new MailClass();
            RutEmpresa = "";
        }

        public class DteClass
        {
            public int folio { get; set; }
            public int tipoDTE { get; set; }
        }

        public class MailClass
        {
            public List<string> to { get; set; }
            public List<string> ccos { get; set; }
            public List<string> ccs { get; set; }
        }
    }
}
