using SDKSimpleFactura.Models.Facturacion;
using System.Collections.Generic;

namespace SDKSimpleFactura.Models.Request
{
    /// <summary>
    /// Request para editar clientes (/editClients)
    /// </summary>
    public class EditarClienteRequest
    {
        public Credenciales Credenciales { get; set; }
        public List<EditarReceptorExterno>? Clientes { get; set; }

        public EditarClienteRequest()
        {
            Credenciales = new Credenciales();
        }
    }

    public class EditarReceptorExterno
    {
        public string Rut { get; set; }
        public string? RazonSocial { get; set; }
        public string? Giro { get; set; }
        public string? DirPart { get; set; }
        public string? DirFact { get; set; }
        public string? CorreoPar { get; set; }
        public string? CorreoFact { get; set; }
        public string? Ciudad { get; set; }
        public string? Comuna { get; set; }

        public EditarReceptorExterno()
        {
            Rut = string.Empty;
        }
    }
}
