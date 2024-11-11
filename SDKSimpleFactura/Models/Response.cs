using Newtonsoft.Json;

namespace SDKSimpleFactura.Models
{
    public class Response<T>
    {
        [JsonProperty("status")]
        public int Status { get; set; }
    
        [JsonProperty("message")]
        public string Message { get; set; }
    
        [JsonProperty("data")]
        public T Data { get; set; }
    
        [JsonProperty("errors")]
        public string[] Errors { get; set; }
    }
}
