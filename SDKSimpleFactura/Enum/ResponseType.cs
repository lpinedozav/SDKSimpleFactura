using System.ComponentModel;

namespace SDKSimpleFactura.Enum
{
    public enum ResponseType
    {
        [Description("Aceptado")]
        Accepted = 3,
        [Description("Aceptado con reparos")]
        AcceptedWithQualms = 4,
        [Description("Rechazado")]
        Rejected = 5
    }
}
