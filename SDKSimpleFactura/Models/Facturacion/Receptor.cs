using SDKSimpleFactura.Helpers;
using System.Xml.Serialization;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class Receptor
    {
        /// <summary>
        /// Rut del receptor del DTE.
        /// Corresponde al RUT del cliente, excepto en la Factura de compra en que se referencia al vendedor.
        /// Con guión y dígito verificador
        /// </summary>
        public string RUTRecep { get; set; }

        private string _codigoInterno;
        /// <summary>
        /// Código interno del receptor.
        /// Para identificación interna del Receptor, por ejemplo código del cliente, número de medidor, etc.
        /// </summary>
        public string CdgIntRecep { get { return _codigoInterno.Truncate(20); } set { _codigoInterno = value; } }

        /// <summary>
        /// Nombre o razón social del receptor.
        /// </summary>
        public string RznSocRecep { get; set; }

        /// <summary>
        /// Receptor extranjero.
        /// </summary>
        public Extranjero? Extranjero { get; set; }

        private string _giro;
        /// <summary>
        /// Giro comercial del receptor.
        /// Glosa impresa indicando giro del receptor.
        /// </summary>
        public string GiroRecep { get { return _giro.Truncate(40); } set { _giro = value; } }

        private string _contacto;
        /// <summary>
        /// Teléfono e Email del contacto del receptor.
        /// Glosa con nombre y teléfono de contacto en empresa del receptor (para registrar el “Atención A:” ).
        /// </summary>
        public string? Contacto { get { return _contacto.Truncate(80); } set { _contacto = value; } }

        /// <summary>
        /// Correo electrónico de contacto en empresa del receptor.
        /// E-mail de contacto en empresa del receptor (para registrar el “Atención A:” ).
        /// </summary>
        public string? CorreoRecep { get; set; }

        private string _direccion;
        /// <summary>
        /// Dirección en la cual se envían los productos o se prestan los servicios.
        /// Dirección Legal del Receptor (registrada en el SII).
        /// En caso de documentos de exportación, corresponde a la dirección en el extranjero del Receptor
        /// </summary>
        public string? DirRecep { get { return _direccion.Truncate(70); } set { _direccion = value; } }

        private string _comuna;
        /// <summary>
        /// Comuna de recepción.
        /// Análogo a Dirección Receptor.
        /// </summary>
        public string CmnaRecep { get { return _comuna.Truncate(20); } set { _comuna = value; } }

        /// <summary>
        /// Ciudad de recepción.
        /// Análogo a Dirección Receptor.
        /// </summary>
        public string CiudadRecep { get; set; }

        private string _dirPostal;
        /// <summary>
        /// Dirección postal.
        /// Análogo a Dirección Receptor.
        /// </summary>
        public string DirPostal { get { return _dirPostal.Truncate(70); } set { _dirPostal = value; } }

        /// <summary>
        /// Comuna postal.
        /// Análogo a Dirección Receptor.
        /// </summary>
        public string CmnaPostal { get; set; }

        /// <summary>
        /// Ciudad postal.
        /// Análogo a Dirección Receptor.
        /// </summary>
        public string CiudadPostal { get; set; }

        public Receptor()
        {
            RUTRecep = string.Empty;
            RznSocRecep = string.Empty;
            CdgIntRecep = string.Empty;
            Extranjero = null;
            GiroRecep = string.Empty;
            Contacto = string.Empty;
            CorreoRecep = string.Empty;
            DirRecep = string.Empty;
            CmnaRecep = string.Empty;
            CiudadRecep = string.Empty;
            DirPostal = string.Empty;
            CmnaPostal = string.Empty;
            CiudadPostal = string.Empty;
        }
    }
}
