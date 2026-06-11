using SDKSimpleFactura.Models.Facturacion;

namespace SDKSimpleFactura.Models.Request
{
    /// <summary>
    /// Datos del certificado digital enviados junto al archivo .pfx/.p12 (/certificado/subir)
    /// </summary>
    public class CertificadoUploadRequest
    {
        public Credenciales Credenciales { get; set; }
        public string RutCertificado { get; set; }
        public string Password { get; set; }

        public CertificadoUploadRequest()
        {
            Credenciales = new Credenciales();
            RutCertificado = string.Empty;
            Password = string.Empty;
        }
    }
}
