namespace SDKSimpleFactura.Models.Clientes
{
    public class ReceptorExternoEnt
    {
        public Guid ReceptorId { get; set; }
        public Guid EmisorId { get; set; }
        public int Rut { get; set; }
        public string Dv { get; set; }
        public string RutFormateado { get; set; }
        public string RazonSocial { get; set; }
        public string NombreFantasia { get; set; }
        public string Giro { get; set; }
        public string DirPart { get; set; }
        public string DirFact { get; set; }
        public string CorreoPar { get; set; }
        public string CorreoFact { get; set; }
        public string Ciudad { get; set; }
        public string Comuna { get; set; }
        public bool Activo { get; set; }
    }

    public class NuevoReceptorExternoRequest
    {
        public string Rut { get; set; }
        public string RazonSocial { get; set; }
        public string Giro { get; set; }
        public string DirPart { get; set; }
        public string DirFact { get; set; }
        public string CorreoPar { get; set; }
        public string CorreoFact { get; set; }
        public string Ciudad { get; set; }
        public string Comuna { get; set; }
    }
}
