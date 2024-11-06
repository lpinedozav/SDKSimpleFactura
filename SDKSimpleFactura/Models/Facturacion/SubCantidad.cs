using SDKSimpleFactura.Helpers;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class SubCantidad
    {
        /// <summary>
        /// Cantidad distribuida.
        /// </summary>
        public double SubQty { get; set; }

        public string _codigo;
        /// <summary>
        /// Codigo descriptivo de la subcantidad.
        /// </summary>
        public string SubCod { get { return _codigo.Truncate(35); } set { _codigo = value; } }

        public SubCantidad()
        {
            SubQty = 0;
            SubCod = string.Empty;
        }
    }
}
