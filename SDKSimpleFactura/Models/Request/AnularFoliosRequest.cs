using SDKSimpleFactura.Models.Facturacion;

namespace SDKSimpleFactura.Models.Request
{
    /// <summary>
    /// Request para anular un rango de folios (/folios/anular)
    /// </summary>
    public class AnularFoliosRequest
    {
        public Credenciales Credenciales { get; set; }
        public int CodigoTipoDte { get; set; }
        public int Ambiente { get; set; }
        public int FolioInicio { get; set; }
        public int FolioTermino { get; set; }
        public string MotivoAnulacion { get; set; }

        public AnularFoliosRequest()
        {
            Credenciales = new Credenciales();
            MotivoAnulacion = string.Empty;
        }
    }
}
