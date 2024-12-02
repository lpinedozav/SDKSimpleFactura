using System;
using SDKSimpleFactura.Helpers;

namespace SDKSimpleFactura.Models.Response
{
    public class TimbrajeEnt
    {
        public Guid TimbrajeId { get; set; }
        public Guid TipoDteId { get; set; }
        public Guid SucursalId { get; set; }
        public int CodigoSii { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaCaf { get; set; }
        public int Desde { get; set; }
        public int Hasta { get; set; }
        public bool Activo { get; set; }

        public Guid EmisorId { get; set; }
        public Guid UsuarioId { get; set; }

        public DateTime FechaVencimiento { get; set; }
        public byte[] Xml { get; set; }
        public string NombreSucursal { get; set; }
        public string TipoDte { get; set; }

        public int FoliosDisponibles { get; set; }
        public int FoliosSinUsar { get; set; }
        public long UltimoFolioEmitido { get; set; }
        public string RutEmisor { get; set; }
        public int Ambiente { get; set; }
        public bool BorrarFolioBloqueado { get; set; }
        public bool Sincronizado { get; set; }
        public DateTime? FechaUltimaSincronizacion { get; set; }
    }

    public class TimbrajeApiEnt
    {
        public TimbrajeApiEnt()
        {
            CodigoSii = 0;
            TipoDte = "";
        }

        public TimbrajeApiEnt(TimbrajeEnt? ent)
        {
            if (ent != null)
            {
                CodigoSii = ent.CodigoSii;
                FechaIngreso = ent.FechaIngreso;
                FechaCaf = ent.FechaCaf;
                Desde = ent.Desde;
                Hasta = ent.Hasta;
                FechaVencimiento = ent.FechaVencimiento;
                TipoDte = Utilidades.ObtenerNombreTipoDTE(ent.CodigoSii);
                FoliosDisponibles = ent.FoliosDisponibles;
                Ambiente = ent.Ambiente;
            }
            else
            {
                CodigoSii = 0;
                TipoDte = "";
            }
        }
        public int CodigoSii { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaCaf { get; set; }
        public int Desde { get; set; }
        public int Hasta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string TipoDte { get; set; }

        public int FoliosDisponibles { get; set; }
        public int Ambiente { get; set; }
    }
}
