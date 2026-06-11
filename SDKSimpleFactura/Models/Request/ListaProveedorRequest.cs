using SDKSimpleFactura.Enum;
using SDKSimpleFactura.Models.Facturacion;

namespace SDKSimpleFactura.Models.Request
{
    /// <summary>
    /// Request para actualizar la lista de un proveedor (/proveedor/update-lista)
    /// </summary>
    public class ListaProveedorRequest
    {
        public Credenciales Credenciales { get; set; }
        public string RutProveedor { get; set; }
        public ListaProveedorEnum ListaProveedor { get; set; }

        public ListaProveedorRequest()
        {
            Credenciales = new Credenciales();
            RutProveedor = string.Empty;
        }
    }
}
