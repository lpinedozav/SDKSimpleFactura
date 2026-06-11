using System;

namespace SDKSimpleFactura.Models.Response
{
    /// <summary>
    /// Tiempo restante de expiración del token (/token/expire)
    /// </summary>
    public class TokenExpireEnt
    {
        public int ExpiresIn { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
