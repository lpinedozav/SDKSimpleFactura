using System.Xml.Serialization;

namespace SDKSimpleFactura.Enum
{
    public enum TipoTransCompra
    {
        [XmlEnum("1")]
        DelGiro = 1,

        [XmlEnum("2")]
        SupermercadosYSimilares = 2,

        [XmlEnum("3")]
        AdquisicionOConstruccionDeBienesInmueblesBBRR = 3,

        [XmlEnum("4")]
        ActivoFijo = 4,

        [XmlEnum("5")]
        CompraIVAUsoComunONoRecuperable = 5,

        [XmlEnum("6")]
        Valor6 = 6,

        [XmlEnum("7")]
        Valor7 = 7
    }

    public enum TipoTransVenta : int
    {
        [XmlEnum("")]
        NotSet = 0,

        [XmlEnum("1")]
        DelGiro = 1,

        [XmlEnum("2")]
        VentasQueNoSonDelGiroActivoFijoYOtros = 2,

        [XmlEnum("3")]
        VentaDeBienesInmueblesBBRR = 3,

        [XmlEnum("4")]
        NCEMR_SoloNCE = 4
    }
}
