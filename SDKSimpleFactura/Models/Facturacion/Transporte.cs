using SDKSimpleFactura.Helpers;
using System;
using System.Globalization;
using System.Xml.Serialization;

namespace SDKSimpleFactura.Models.Facturacion
{
    /// <summary>
    /// Informacíón del Transporte.
    /// Esta información se debe registrar sólo si se dispone de la información al momento de confeccionar el documento electrónico. En caso contrario, bastará que vaya escrita en la representación impresa que acompaña el traslado de bienes.
    /// Relevante si Indicador Tipo de Despacho 2 (Emisor al cliente) o 3 (Emisor a otras instalaciones).
    /// </summary>
    public class Transporte
    {
        public string? _patente;
        /// <summary>
        /// Patente del vehículo que trasnporta los bienes.
        /// </summary>
        public string? Patente { get { return _patente.Truncate(8); } set { _patente = value; } }

        private string? _patenteCarro;
        /// <summary>
        /// Patente del carro o remolque.
        /// </summary>
        public string? PatenteCarro { get { return _patenteCarro?.Truncate(8); } set { _patenteCarro = value; } }

        /// <summary>
        /// Rut del transportista.
        /// Con guión y dígito verificador.
        /// </summary>
        public string? RUTTrans { get; set; }

        /// <summary>
        /// Chofer
        /// </summary>
        public Chofer? Chofer { get; set; }

        private string? _dirDestino;
        /// <summary>
        /// Dirección de destino.
        /// Datos correspondientes a la dirección de destino en documento que acompaña productos o a la dirección en que se otorga el servicio en caso de servicios periódicos.
        /// Aplica si el destino es distinto de Encabezado.Receptor.DirecciónReceptor o de Encabezado.Emisor.DirecciónEmisor en caso de Factura de compra.
        /// </summary>
        public string? DirDest { get { return _dirDestino.Truncate(70); } set { _dirDestino = value; } }

        /// <summary>
        /// Comuna de destino.
        /// Análogo a dirección de destino.
        /// </summary>
        public string? CmnaDest { get; set; }

        /// <summary>
        /// Ciudad de destino.
        /// Análogo a dirección de destino,
        /// </summary>
        public string? CiudadDest { get; set; }

        /// <summary>
        /// Documentos de exportación y guías de despacho.
        /// </summary>
        public Aduana? Aduana { get; set; }

        /// <summary>
        /// Fecha de salida (AAAA-MM-DD).
        /// Do not set this property, set FchSalida instead.
        /// </summary>
        public string? FechaSalidaString { get; set; }
        public bool ShouldSerializeFechaSalidaString() { return FchSalida != DateTime.MinValue; }
        /// <summary>
        /// Fecha de salida.
        /// </summary>
        public DateTime FchSalida
        {
            get { return string.IsNullOrEmpty(FechaSalidaString) ? DateTime.MinValue : DateTime.Parse(FechaSalidaString, CultureInfo.InvariantCulture); }
            set { FechaSalidaString = value == DateTime.MinValue ? null : value.ToString("yyyy-MM-dd"); }
        }

        /// <summary>
        /// Hora de salida (hh:mm:ss).
        /// Do not set this property, set HraSalida instead.
        /// </summary>
        public string? HoraSalidaString { get; set; }
        public bool ShouldSerializeHoraSalidaString() { return HraSalida != TimeSpan.Zero; }
        /// <summary>
        /// Hora de salida.
        /// </summary>
        public TimeSpan HraSalida
        {
            get { return string.IsNullOrEmpty(HoraSalidaString) ? TimeSpan.Zero : TimeSpan.Parse(HoraSalidaString, CultureInfo.InvariantCulture); }
            set { HoraSalidaString = value == TimeSpan.Zero ? null : value.ToString(@"hh\:mm\:ss"); }
        }

        /// <summary>
        /// Fecha de llegada (AAAA-MM-DD).
        /// Do not set this property, set FchLlegada instead.
        /// </summary>
        public string? FechaLlegadaString { get; set; }
        public bool ShouldSerializeFechaLlegadaString() { return FchLlegada != DateTime.MinValue; }
        /// <summary>
        /// Fecha de llegada.
        /// </summary>
        public DateTime FchLlegada
        {
            get { return string.IsNullOrEmpty(FechaLlegadaString) ? DateTime.MinValue : DateTime.Parse(FechaLlegadaString, CultureInfo.InvariantCulture); }
            set { FechaLlegadaString = value == DateTime.MinValue ? null : value.ToString("yyyy-MM-dd"); }
        }

        public Transporte()
        {
            FchSalida = DateTime.MinValue;
            HraSalida = TimeSpan.Zero;
            FchLlegada = DateTime.MinValue;
        }
    }

}
