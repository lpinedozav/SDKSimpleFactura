namespace SDKSimpleFactura.Models.Response
{
    public class ActividadeconomicaApiEnt
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }

        public ActividadeconomicaApiEnt()
        {
            Descripcion = string.Empty;
        }
    }
}
