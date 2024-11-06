using SDKSimpleFactura.Helpers;
using System.Xml.Serialization;


namespace SDKSimpleFactura.Models.Facturacion
{
    public class CodigoItem
    {
        private string _tipoCodigo;
        /// <summary>
        /// Tipo de codificación utilizada para el item.
        /// Standart: EAN, PLU, DUN14, INT1, INT2, EAN128, Interna, etc.
        /// </summary>
        public string TpoCodigo { get { return _tipoCodigo.Truncate(10); } set { _tipoCodigo = value; } }

        private string _valorCodigo;
        /// <summary>
        /// Valor del código para TipoCodigo.
        /// </summary>
        public string VlrCodigo { get { return _valorCodigo.Truncate(35); } set { _valorCodigo = value; } }

        public CodigoItem()
        {

        }
    }
}
