using System.Text.Json.Serialization;

namespace SDKSimpleFactura.Models.Productos
{
    public class ImpuestoEnt
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int ImpuestoId { get; set; }
        public string Nombre { get; set; }
        public double Valor { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool IsRetencion { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool Activo { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int TipoImpuesto { get; set; }
        public double Tasa { get; set; }
        public int Codigo { get; set; }
    }
}
