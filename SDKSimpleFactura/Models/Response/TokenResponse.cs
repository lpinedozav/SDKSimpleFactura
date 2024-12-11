using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDKSimpleFactura.Models.Response
{
    public class TokenResponse
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
        [JsonProperty("expiresAt")]
        public DateTime ExpiresAt { get; set; }
        [JsonProperty("expiresIn")]
        public int ExpiresIn { get; set; }
    }
}
