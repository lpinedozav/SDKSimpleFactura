using System.Xml.Serialization;

namespace SDKSimpleFactura.Enum
{
    public class MedioPago
    {
        /// <summary>
        /// Indica las modalidades de pago posibles
        /// </summary>
        public enum MedioPagoEnum
        {
            /// <summary>
            /// No se ha definido un valor aún.
            /// </summary>
            NotSet,
            /// <summary>
            /// Cheque
            /// </summary>
            CH, 
            /// <summary>
            /// Cheque a fecha
            /// </summary>
            CF, 
            /// <summary>
            /// Letra
            /// </summary>
            LT, 
            /// <summary>
            /// Efectivo
            /// </summary>
            EF,
            /// <summary>
            /// Pago a cuenta corriente
            /// </summary>
            PE,
            /// <summary>
            /// Tarjeta de credito
            /// </summary>
            TC,
            /// <summary>
            /// Otro
            /// </summary>
            OT
        }

        /// <summary>
        /// Indica las modalidades de pago posibles para boletas electrónicas
        /// </summary>
        public enum MedioPagoBoletaEnum : int
        {
            /// <summary>
            /// No se ha asignado un valor aún.
            /// </summary>
            [XmlEnum("")]
            NotSet = 0,
            /// <summary>
            /// Efectivo
            /// </summary>
            [XmlEnum("1")]
            Efectivo = 1,
            /// <summary>
            /// Pago Electrónico
            /// </summary>
            [XmlEnum("2")]
            PagoElectrónico = 2,
            /// <summary>
            /// Transferencia Electrónica
            /// </summary>
            [XmlEnum("3")]
            TransferenciaElectrónica = 3,
            /// <summary>
            /// Cheque
            /// </summary>
            [XmlEnum("4")]
            Cheque = 4,
            /// <summary>
            /// Otro
            /// </summary>
            [XmlEnum("5")]
            Otro = 5,
        }
    }
}
