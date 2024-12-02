using System;
using System.Collections.Generic;
namespace SDKSimpleFactura.Models.Request
{
    public class ProductoExternoEnt
    {
        public Guid ProductoId { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public bool Exento { get; set; }
        public List<ImpuestoProductoExternoEnt> Impuestos { get; set; }

        public ProductoExternoEnt()
        {
            Impuestos = new List<ImpuestoProductoExternoEnt>();
        }
    }
    public class ImpuestoProductoExternoEnt
    {
        public int CodigoSii { get; set; }
        public string NombreImp { get; set; }
        public double Tasa { get; set; }
    }
    public class NuevoProductoExternoRequest
    {
        public string Nombre { get; set; }
        public string CodigoBarra { get; set; }
        public string UnidadMedida { get; set; }
        public double Precio { get; set; }
        public bool Exento { get; set; }
        public bool TieneImpuestos { get; set; }
        public List<int> Impuestos { get; set; }
    }
}
