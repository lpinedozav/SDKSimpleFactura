using System;

namespace SDKSimpleFactura.Models.Response
{
    /// <summary>
    /// Respuesta de la consulta de última sincronización con el SII (/sii/lastsync/{mes}/{anio})
    /// </summary>
    public class LastSyncResponse
    {
        public string? Empresa { get; set; }
        public string? Tipo { get; set; }
        public PeriodoSync? Periodo { get; set; }
        public LastSyncBlock? Current_Month { get; set; }
        public LastSyncBlock? Previous_Month { get; set; }
    }

    public class PeriodoSync
    {
        public int Mes { get; set; }
        public int Anio { get; set; }
    }

    public class LastSyncBlock
    {
        public DateTime? Last_Sync { get; set; }
        public string? Source { get; set; }
    }
}
