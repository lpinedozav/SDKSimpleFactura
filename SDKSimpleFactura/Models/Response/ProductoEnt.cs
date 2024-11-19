namespace SDKSimpleFactura.Models.Response
{
    public class ProductoEnt
    {
        public Guid ProductoId { get; set; }
        public string? CodigoBarra { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public bool Exento { get; set; }
        public bool Activo { get; set; }
        public Guid EmisorId { get; set; }
        public Guid SucursalId { get; set; }
        public string? UnidadMedida { get; set; }
        public List<ImpuestoEnt> Impuestos { get; set; }

        public string NombreCategoria => "Sin Categoría";
        public string NombreMarca => "Sin Marca";
        public int Stock => 50;

        public ProductoEnt()
        {
            Impuestos = new List<ImpuestoEnt>();
            Nombre = "";
        }
    }
}
