namespace SDKSimpleFactura.Enum
{
    /// <summary>
    /// Motivos de observación de una BHE recibida
    /// </summary>
    public enum ObservacionBoletaHonorarioEnum
    {
        /// <summary>
        /// Sin Asignar
        /// </summary>
        NotSet = 0,
        /// <summary>
        /// No se reconoce la relación contractual o comercial con el emisor.
        /// </summary>
        NoReconoceRelacion = 1,
        /// <summary>
        /// No se reconoce al emisor de la BHE.
        /// </summary>
        NoReconoceEmisor = 2,
    }
}
