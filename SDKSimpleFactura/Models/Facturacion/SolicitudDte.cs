namespace SDKSimpleFactura.Models.Facturacion
{
    public class SolicitudDte
    {
        public Credenciales Credenciales { get; set; }
        public DteReferenciadoExterno DteReferenciadoExterno { get; set; }
        /// <summary>
        /// Título del pie de página para la representación impresa (opcional).
        /// </summary>
        public string? TituloPiePagina { get; set; }
        /// <summary>
        /// Mensaje del pie de página para la representación impresa (opcional).
        /// </summary>
        public string? Mensaje { get; set; }
    }
}
