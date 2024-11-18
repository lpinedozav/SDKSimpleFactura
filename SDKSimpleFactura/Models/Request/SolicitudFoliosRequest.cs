namespace SDKSimpleFactura.Models.Request
{
    public class SolicitudFoliosRequest
    {
        public string RutEmpresa { get; set; }
        public int TipoDTE { get; set; }
        public int? Ambiente { get; set; }
    }
}
