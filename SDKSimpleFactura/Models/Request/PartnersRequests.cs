using SDKSimpleFactura.Enum;
using SDKSimpleFactura.Models.Facturacion;
using System;
using System.Collections.Generic;
using static SDKSimpleFactura.Enum.Ambiente;

namespace SDKSimpleFactura.Models.Request
{
    /// <summary>
    /// Request para obtener el resumen de DTEs de un partner (/partners/dtes/resumen)
    /// </summary>
    public class PartnerDteResumenRequest
    {
        public Credenciales Credenciales { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }

        public PartnerDteResumenRequest()
        {
            Credenciales = new Credenciales();
        }
    }

    /// <summary>
    /// Request para enrolar una empresa (/partners/enrolamiento-empresa)
    /// </summary>
    public class WizardEmisorRequest
    {
        public EmisorEnrolamiento Emisor { get; set; }
        public SucursalEnrolamiento Sucursal { get; set; }
        public List<int> ActividadesEconomicas { get; set; }
        public PlanUsuarioEnum Plan { get; set; }

        public WizardEmisorRequest()
        {
            Emisor = new EmisorEnrolamiento();
            Sucursal = new SucursalEnrolamiento();
            ActividadesEconomicas = new List<int>();
        }
    }

    public class EmisorEnrolamiento
    {
        public string RutEmpresa { get; set; }
        public string RazonSocial { get; set; }
        public string RutRepresentanteLegal { get; set; }

        public string Giro { get; set; }

        public string Email { get; set; }
        public string DireccionFacturacion { get; set; }

        public string Ciudad { get; set; }
        public string Comuna { get; set; }

        public string? Telefono { get; set; }

        public DateTime FechaResolucion { get; set; }
        public int NumeroResolucion { get; set; }
        public AmbienteEnum Ambiente { get; set; }

        public string? PasswordSii { get; set; }
        public string? UnidadSii { get; set; }

        public EmisorEnrolamiento()
        {
            RutEmpresa = string.Empty;
            RazonSocial = string.Empty;
            RutRepresentanteLegal = string.Empty;
            Giro = string.Empty;
            Email = string.Empty;
            DireccionFacturacion = string.Empty;
            Ciudad = string.Empty;
            Comuna = string.Empty;
            Ambiente = AmbienteEnum.Certificacion;
        }
    }

    public class SucursalEnrolamiento
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public SucursalEnrolamiento()
        {
            Nombre = "Casa Matriz";
            Direccion = "Dirección 1";
        }
    }
}
