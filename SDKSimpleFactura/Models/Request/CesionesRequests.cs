using SDKSimpleFactura.Models.Facturacion;
using System;
using static SDKSimpleFactura.Enum.Ambiente;
using static SDKSimpleFactura.Enum.TipoDTE;

namespace SDKSimpleFactura.Models.Request
{
    /// <summary>
    /// Request para obtener el XML AEC de una cesión (/cessions/xml)
    /// </summary>
    public class CessionXmlRequest
    {
        public Credenciales Credenciales { get; set; }
        public long Folio { get; set; }
        public DTEType CodigoTipoDte { get; set; }
        public AmbienteEnum Ambiente { get; set; }

        public CessionXmlRequest()
        {
            Credenciales = new Credenciales();
        }
    }

    /// <summary>
    /// Request para listar personas autorizadas de cesión (/cessions/personasAutorizadas)
    /// </summary>
    public class AuthorizedPersonsListRequest
    {
        public Credenciales Credenciales { get; set; }

        public AuthorizedPersonsListRequest()
        {
            Credenciales = new Credenciales();
        }
    }

    /// <summary>
    /// Request para agregar una persona autorizada de cesión (/cessions/personasAutorizadas/agregar)
    /// </summary>
    public class AddAuthorizedPersonRequest
    {
        public Credenciales Credenciales { get; set; }
        public string RutPersonaAutorizada { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }

        public AddAuthorizedPersonRequest()
        {
            Credenciales = new Credenciales();
            RutPersonaAutorizada = string.Empty;
            Nombre = string.Empty;
            Correo = string.Empty;
        }
    }

    /// <summary>
    /// Request para listar cesionarios (/cessions/cesionarios)
    /// </summary>
    public class CessionariesListRequest
    {
        public Credenciales Credenciales { get; set; }
        public string? RutCesionario { get; set; }
        public string? RazonSocial { get; set; }
        public bool IncluirInactivos { get; set; }

        public CessionariesListRequest()
        {
            Credenciales = new Credenciales();
        }
    }

    /// <summary>
    /// Request para agregar un cesionario (/cessions/cesionarios/agregar)
    /// </summary>
    public class AddCessionaryRequest
    {
        public Credenciales Credenciales { get; set; }
        public string RutCesionario { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public int Fono { get; set; }
        public string NombreContacto { get; set; }

        public AddCessionaryRequest()
        {
            Credenciales = new Credenciales();
            RutCesionario = string.Empty;
            RazonSocial = string.Empty;
            Direccion = string.Empty;
            Correo = string.Empty;
            NombreContacto = string.Empty;
        }
    }

    /// <summary>
    /// Request para listar cesiones emitidas (/cessions/Issued)
    /// </summary>
    public class ListaCesionRequest
    {
        public Credenciales Credenciales { get; set; }
        public AmbienteEnum Ambiente { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }

        public ListaCesionRequest()
        {
            Credenciales = new Credenciales();
        }
    }

    /// <summary>
    /// Request para obtener trazas de una cesión emitida (/cessions/trazasIssued)
    /// </summary>
    public class CesionTrazaRequest
    {
        public Credenciales Credenciales { get; set; }
        public int Folio { get; set; }
        public AmbienteEnum Ambiente { get; set; }

        public CesionTrazaRequest()
        {
            Credenciales = new Credenciales();
        }
    }
}
