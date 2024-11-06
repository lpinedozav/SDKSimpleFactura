using SDKSimpleFactura.Helpers;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class TipoBulto
    {
        /// <summary>
        /// Código según tabla "Tipos de bultos" de Aduana.
        /// </summary>
        public Enum.CodigosAduana.TipoBultoEnum CodTpoBultos { get; set; }
        /// <summary>
        /// Cantidad de Bultos
        /// </summary>
        public int CantBultos { get; set; }

        private string _marcas;
        /// <summary>
        /// Identificación de marcas, cuando es distinto de contenedor.
        /// </summary>
        public string Marcas { get { return _marcas.Truncate(255); } set { _marcas = value; } }

        private string _idContainer;
        /// <summary>
        /// Se utiliza cuando el tipo de bulto es contenedor.
        /// </summary>
        public string IdContainer { get { return _idContainer.Truncate(25); } set { _idContainer = value; } }

        private string _sello;
        /// <summary>
        /// Sello contenedor, con dígito verificador.
        /// </summary>
        public string Sello { get { return _sello.Truncate(20); } set { _sello = value; } }

        private string _emisorSello;
        /// <summary>
        /// Nombre emisor sello.
        /// </summary>
        public string EmisorSello { get { return _emisorSello.Truncate(70); } set { _emisorSello = value; } }

        public TipoBulto()
        {
            CodTpoBultos = 0;
            CantBultos = 0;
            Marcas = string.Empty;
            IdContainer = string.Empty;
            Sello = string.Empty;
            EmisorSello = string.Empty;
        }
    }
}
