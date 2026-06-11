namespace SDKSimpleFactura.Models.Response
{
    /// <summary>
    /// Resumen de DTEs de un partner (/partners/dtes/resumen)
    /// </summary>
    public class PartnerDteResumenEnt
    {
        public int Dtes { get; set; }
        public string NombrePlan { get; set; }
        public int DtesAdicionales { get; set; }

        public PartnerDteResumenEnt()
        {
            NombrePlan = string.Empty;
        }
    }
}
