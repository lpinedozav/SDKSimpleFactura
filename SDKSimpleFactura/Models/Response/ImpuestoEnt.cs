namespace SDKSimpleFactura.Models.Response
{
    public class ImpuestoEnt
    {
        public int ImpuestoId { get; set; }
        public string Nombre { get; set; }
        public double Valor { get; set; }
        public bool IsRetencion { get; set; }
        public bool Activo { get; set; }
        public int TipoImpuesto { get; set; }
        public double Tasa { get; set; }
        public int Codigo { get; set; }
    }
}
