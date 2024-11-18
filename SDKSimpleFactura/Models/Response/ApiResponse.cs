namespace SDKSimpleFactura.Models.Response
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public T? Data { get; set; }
        public string Errores { get; set; }
    }
}
