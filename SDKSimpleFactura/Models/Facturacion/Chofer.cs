using SDKSimpleFactura.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class Chofer
    {
        /// <summary>
        /// Rut del chofer.
        /// Rut Chofer que realiza el transporte de mercaderías. 
        /// Con guión y dígito verificador.
        /// </summary>
        public string RUTChofer { get; set; }

        private string _nombre;
        /// <summary>
        /// Nombre del chofer.
        /// </summary>
        public string NombreChofer { get { return _nombre.Truncate(30); } set { _nombre = value; } }

        public Chofer()
        {
            RUTChofer = string.Empty;
            NombreChofer = string.Empty;
        }
    }
}
