using SDKSimpleFactura.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class Extranjero
    {
        private string _id;
        /// <summary>
        /// Número identificador del receptor extranjero.
        /// Corresponde al número o código de identificación personal del receptor extranjero, otorgado por la Administración tributaria extranjera u organismo Gubernamental competente.
        /// Se deben incluir guiones y dígitos verificadores.
        /// </summary>
        public string NumId { get { return _id.Truncate(20); } set { _id = value; } }

        private string _nacionalidad;
        /// <summary>
        /// Nacionalidad del receptor extranjero.
        /// Corresponde a la nacionalidad del extranjero, según tabla de países de Aduana. 
        /// https://www.aduana.cl/compendio-de-normas-anexo-51/aduana/2008-02-18/165942.html Anexo 51-9.
        /// </summary>
        public Enum.CodigosAduana.Paises Nacionalidad { get; set; }

        public Extranjero()
        {
            NumId = string.Empty;
            Nacionalidad = Enum.CodigosAduana.Paises.NotSet;
        }
    }
}
