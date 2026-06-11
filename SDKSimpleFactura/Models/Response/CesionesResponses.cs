namespace SDKSimpleFactura.Models.Response
{
    /// <summary>
    /// Persona autorizada de cesión (/cessions/personasAutorizadas)
    /// </summary>
    public class AuthorizedPersonEnt
    {
        public string RutPersonaAutorizada { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public bool Activo { get; set; }

        public AuthorizedPersonEnt()
        {
            RutPersonaAutorizada = string.Empty;
            Nombre = string.Empty;
            Correo = string.Empty;
        }
    }

    /// <summary>
    /// Cesionario (/cessions/cesionarios)
    /// </summary>
    public class CessionaryEnt
    {
        public string RutCesionario { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public int Fono { get; set; }
        public string NombreContacto { get; set; }
        public bool Activo { get; set; }

        public CessionaryEnt()
        {
            RutCesionario = string.Empty;
            RazonSocial = string.Empty;
            Direccion = string.Empty;
            Correo = string.Empty;
            NombreContacto = string.Empty;
        }
    }

    /// <summary>
    /// Cesión emitida (/cessions/Issued)
    /// </summary>
    public class CesionEnt
    {
        public long Folio { get; set; }
        public string? RutPersonaAutorizada { get; set; }
        public string? NombrePersonaAutorizada { get; set; }
        public string? FechaEmision { get; set; }
        public long MontoTotal { get; set; }
        public string? Estado { get; set; }
        public string? Trackid { get; set; }
        public bool Anulado { get; set; }
        public int CodigoTipoDte { get; set; }
        public string? RutCesionario { get; set; }
        public string? RazonSocialCesionario { get; set; }
        public string? CorreoCesionario { get; set; }
        public string? FechaVencimientoFactura { get; set; }
    }
}
