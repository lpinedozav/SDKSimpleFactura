using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class Retenedor
    {
        /// <summary>
        /// Indicador agente retenedor.
        /// Obligatorio para agentes retenedores, indica para cada transacción si es agente retenedor del producto que está vendiendo. 
        /// </summary>
        public string IndAgente { get; set; }

        /// <summary>
        /// Monto base faenamiento.
        /// Sólo para transacciones realizadas por Agentes Retenedores, según códigos de retención 17.
        /// </summary>
        public int MntBaseFaena { get; set; }

        /// <summary>
        /// Márgenes de comercialización.
        /// Sólo para transacciones realizadas por Agentes Retenedores, según códigos de retención 14 y 50.
        /// </summary>
        public int MntMargComer { get; set; }

        /// <summary>
        /// Precio unitario neto consumidor final.
        /// Sólo para transacciones realizadas por Agentes Retenedores, según códigos de retención 14, 17 y 50.
        /// </summary>
        public int PrcConsFinal { get; set; }

        public Retenedor()
        {
            IndAgente = string.Empty;
            MntBaseFaena = 0;
            MntMargComer = 0;
            PrcConsFinal = 0;
        }
    }
}
