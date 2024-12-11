using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SDKSimpleFactura.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SDKSimpleFactura.Models.Response;

namespace SDKSimpleFactura.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string _accessToken = string.Empty;
        private DateTime _expiresAt = DateTime.MinValue;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public AuthenticationService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string> GetTokenAsync()
        {
            if (string.IsNullOrEmpty(_accessToken) || DateTime.UtcNow >= _expiresAt)
            {
                await _semaphore.WaitAsync();
                try
                {
                    if (string.IsNullOrEmpty(_accessToken) || DateTime.UtcNow >= _expiresAt)
                    {
                        var tokenEndpoint = "/token";
                        var email = _configuration["SDKSettings:Username"];
                        var password = _configuration["SDKSettings:Password"];

                        var requestContent = new StringContent(
                            JsonConvert.SerializeObject(new { email, password }),
                            Encoding.UTF8,
                            "application/json"
                        );

                        var response = await _httpClient.PostAsync(tokenEndpoint, requestContent);
                        var responseContent = await response.Content.ReadAsStringAsync();

                        if (response.IsSuccessStatusCode)
                        {
                            var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseContent);
                            _accessToken = tokenResponse.AccessToken;
                            _expiresAt = tokenResponse.ExpiresAt.ToUniversalTime();
                        }
                        else
                        {
                            throw new Exception($"Error al obtener el token: {responseContent}");
                        }
                    }
                }
                finally
                {
                    _semaphore.Release();
                }
            }

            return _accessToken;
        }
    }
}
