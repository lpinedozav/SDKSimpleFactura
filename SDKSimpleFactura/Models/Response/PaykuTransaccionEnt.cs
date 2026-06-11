namespace SDKSimpleFactura.Models.Response
{
    /// <summary>
    /// Transacción Payku (/payku/transacciones)
    /// </summary>
    public class PaykuTransaccionEnt
    {
        public string? Fecha { get; set; }
        public double Monto { get; set; }
        public string? Estado { get; set; }
        public string? ReceptorRut { get; set; }
        public string? ReceptorRazonSocial { get; set; }
        public double Porcentaje { get; set; }
        public double MontoNeto { get; set; }
        public long DteFolio { get; set; }
        public string? Tipo { get; set; }
    }
}
