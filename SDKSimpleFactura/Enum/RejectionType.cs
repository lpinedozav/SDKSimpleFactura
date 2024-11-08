using System.ComponentModel;

namespace SDKSimpleFactura.Enum
{
    public enum RejectionType
    {
        [Description("Reclamo al Contenido del Documento")]
        RCD = 1,
        [Description("Reclamo por Falta Parcial de Mercaderías")]
        RFP = 3,
        [Description("Reclamo por Falta Total de Mercaderías")]
        RFT = 4
    }
}
