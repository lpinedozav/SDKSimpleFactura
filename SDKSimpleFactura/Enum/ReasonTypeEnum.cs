using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKSimpleFactura.Enum
{
    public enum ReasonTypeEnum
    {
        [Description("No Asignado")]
        NotSet = 0,
        [Description("Error de digitación")]
        ErrorDigitacion = 1,
        [Description("Reclamo de Cliente")]
        ReclamoCliente = 2,
        [Description("Datos Desactualizados")]
        DatosDesactualizados = 3,
        [Description("Intereses por Mora")]
        InteresesMora = 4,
        [Description("Intereses por Cambio de Fecha")]
        InteresesCambioFecha = 5,
        [Description("Otros")]
        Otros = 6
    }
}
