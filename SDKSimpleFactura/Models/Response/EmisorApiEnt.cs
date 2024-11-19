namespace SDKSimpleFactura.Models.Response
{
    public class EmisorApiEnt
    {
        public string Rut { get; set; }
        public string RazonSocial { get; set; }
        public string Giro { get; set; }
        public string? DirPart { get; set; }
        public string DirFact { get; set; }
        public string? CorreoPar { get; set; }
        public string CorreoFact { get; set; }
        public string? Ciudad { get; set; }
        public string Comuna { get; set; }
        public int NroResol { get; set; }
        public string? UnidadSII { get; set; }
        public DateTime FechaResol { get; set; }
        public int Ambiente { get; set; }
        public decimal Telefono { get; set; }
        public string RutRepresentanteLegal { get; set; }
        public List<ActividadeconomicaApiEnt> ActividadesEconomicas { get; set; }
        public EmisorApiEnt()
        {
            ActividadesEconomicas = new List<ActividadeconomicaApiEnt>();
        }
    }
}
