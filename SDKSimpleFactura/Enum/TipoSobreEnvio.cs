using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
