using Newtonsoft.Json;
using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Models;
using System.Text;

namespace SDKSimpleFactura.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ApiResponse<TResponse>> PostAsync<TRequest, TResponse>(string url, TRequest request)
        {
            var jsonRequest = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<TResponse>(responseContent);
                return new ApiResponse<TResponse>
                {
                    IsSuccess = true,
                    Data = result
                };
            }
            else
            {
                string? errorMessage = responseContent;
                return new ApiResponse<TResponse>
                {
                    IsSuccess = false,
                    StatusCode = (int)response.StatusCode,
                    Errores = errorMessage
                };
            }
        }
        public async Task<ApiResponse<byte[]>> PostForByteArrayAsync<TRequest>(string url, TRequest request)
        {
            var jsonRequest = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            var responseContent = await response.Content.ReadAsByteArrayAsync();
            if (response.IsSuccessStatusCode)
            {
                return new ApiResponse<byte[]>
                {
                    IsSuccess = true,
                    Data = responseContent
                };
            }
            else
            {
                string? errorMessage = $"Error en la peticion: {responseContent}";
                return new ApiResponse<byte[]>
                {
                    IsSuccess = false,
                    StatusCode = (int)response.StatusCode,
                    Errores = errorMessage
                };
            }
        }
        public async Task<ApiResponse<TResponse>> PostMultipartAsync<TResponse>(string url, MultipartFormDataContent content)
        {
            var response = await _httpClient.PostAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<TResponse>(responseContent);
                return new ApiResponse<TResponse>
                {
                    IsSuccess = true,
                    Data = result
                };
            }
            else
            {
                string? errorMessage = responseContent;
                return new ApiResponse<TResponse>
                {
                    IsSuccess = false,
                    StatusCode = (int)response.StatusCode,
                    Errores = errorMessage
                };
            }
        }
    }

}
