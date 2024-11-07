using System.ComponentModel;

namespace SDKSimpleFactura.Enum
{
    public enum TipoSalida
    {
        [Description("Base64")] Base64 = 0,
        [Description("XML")] XML = 1
    }
}
