namespace SDKSimpleFactura.Models.Folios
{
    public class FoliosAnulablesEnt
    {
        public long Desde { get; set; }
        public long Hasta { get; set; }

        public long Cantidad
        {
            get => Hasta - Desde + 1;
        }

    }
}
