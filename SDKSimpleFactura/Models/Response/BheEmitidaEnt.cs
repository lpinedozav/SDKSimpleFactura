namespace SDKSimpleFactura.Models.Response
{
    /// <summary>
    /// Respuesta de la emisión de una BHE (/bhe/emitir y /bhe/terceros/emitir)
    /// </summary>
    public class BheEmitidaEnt
    {
        public long Folio { get; set; }
        public string? CodigoBarras { get; set; }
        public string? FechaEmision { get; set; }
        public string? PdfBase64 { get; set; }
    }
}
