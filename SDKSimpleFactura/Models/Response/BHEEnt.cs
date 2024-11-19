namespace SDKSimpleFactura.Models.Response
{
    public class BHEEnt
    {
        public int? Folio { get; set; }
        public string? FechaEmision { get; set; }
        public string? CodigoBarra { get; set; }
        public EmisorEnt? Emisor { get; set; }
        public ReceptorEnt? Receptor { get; set; }
        public TotalesEnt? Totales { get; set; }
        public string? Estado { get; set; }
        public string? DescripcionAnulacion { get; set; }
    }
    public class EmisorEnt
    {
        public string? rutEmisor { get; set; }
        public string? Direccion { get; set; }
        public string? RazonSocial { get; set; }
    }
    public class ReceptorEnt
    {
        public string? Rut { get; set; }
        public string? Comuna { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Region { get; set; }
    }
    public class TotalesEnt
    {
        public decimal? TotalHonorarios { get; set; }
        public decimal? Bruto { get; set; }
        public decimal? Liquido { get; set; }
        public decimal? Pagado { get; set; }
        public decimal? Retenido { get; set; }
    }

}
