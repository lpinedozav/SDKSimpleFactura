using System.ComponentModel;

namespace SDKSimpleFactura.Enum
{
    public enum TipoSobreEnvio
    {
        [Description("Al SII")]
        AlSII = 0,
        [Description("Al Receptor")]
        AlReceptor = 1,
    }
}
