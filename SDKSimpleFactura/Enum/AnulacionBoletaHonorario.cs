namespace SDKSimpleFactura.Enum
{
    /// <summary>
    /// Motivos de anulación de una BHE
    /// </summary>
    public enum AnulacionBoletaHonorarioEnum
    {
        /// <summary>
        /// Sin Asignar
        /// </summary>
        NotSet = 0,
        /// <summary>
        /// No se efectuó el pago de los servicios por parte del receptor
        /// </summary>
        ServicioNoPagado = 1,
        /// <summary>
        /// No se efectuó la prestación de servicios
        /// </summary>
        ServicioNoEfectuado = 2,
        /// <summary>
        /// Error en la digitación
        /// </summary>
        ErrorDigitacion = 3,
    }
}
