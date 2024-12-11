using Microsoft.Extensions.Configuration;
using Moq.Protected;
using Moq;
using Newtonsoft.Json;
using SDKSimpleFactura.Models.Response;
using SDKSimpleFactura.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SDKSimpleFacturaTests
{
    [TestClass]
    public class AuthenticationServiceTests
    {
        private Mock<HttpMessageHandler> _mockHttpMessageHandler;
        private HttpClient _httpClient;
        private IConfiguration _configuration;
        private AuthenticationService _authenticationService;

        [TestInitialize]
        public void Setup()
        {
            // Inicializar el mock de HttpMessageHandler
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            // Configuración en memoria para las pruebas
            var inMemorySettings = new Dictionary<string, string> {
                {"SDKSettings:TokenEndpoint", "/token"},
                {"SDKSettings:Email", "demo@chilesystems.com"},
                {"SDKSettings:Password", "Rv8Il4eV"}
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            // Crear HttpClient con el handler mockeado
            _httpClient = new HttpClient(_mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://api.tuempresa.com/")
            };

            // Inicializar AuthenticationService
            _authenticationService = new AuthenticationService(_httpClient, _configuration);
        }

        [TestMethod]
        public async Task GetTokenAsync_ShouldReuseToken_WhenCalledMultipleTimesWithinExpiry()
        {
            // Arrange
            var expectedToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...";
            var tokenResponse = new TokenResponse
            {
                AccessToken = expectedToken,
                ExpiresAt = DateTime.UtcNow.AddHours(24)
            };

            // Configurar el mock para devolver el tokenResponse
            _mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                   "SendAsync",
                   ItExpr.Is<HttpRequestMessage>(req =>
                       req.Method == HttpMethod.Post &&
                       req.RequestUri.AbsolutePath.EndsWith("/token")
                   ),
                   ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(tokenResponse)),
                })
                .Verifiable();

            // Act
            var token1 = await _authenticationService.GetTokenAsync();
            var token2 = await _authenticationService.GetTokenAsync();
            var token3 = await _authenticationService.GetTokenAsync();

            // Assert
            Assert.AreEqual(expectedToken, token1);
            Assert.AreEqual(expectedToken, token2);
            Assert.AreEqual(expectedToken, token3);

            // Verificar que solo se hizo una llamada al endpoint de token
            _mockHttpMessageHandler.Protected().Verify(
               "SendAsync",
               Times.Once(), // Solo una llamada
               ItExpr.Is<HttpRequestMessage>(req =>
                   req.Method == HttpMethod.Post &&
                   req.RequestUri.AbsolutePath.EndsWith("/token")
               ),
               ItExpr.IsAny<CancellationToken>()
            );
        }

        [TestMethod]
        public async Task GetTokenAsync_ShouldFetchNewToken_WhenCurrentTokenHasExpired()
        {
            // Arrange
            var initialToken = "initial_token";
            var newToken = "new_token";

            var initialTokenResponse = new TokenResponse
            {
                AccessToken = initialToken,
                ExpiresAt = DateTime.UtcNow.AddSeconds(1)
            };

            var newTokenResponse = new TokenResponse
            {
                AccessToken = newToken,
                ExpiresAt = DateTime.UtcNow.AddHours(24)
            };

            // Configurar el mock para devolver el initialTokenResponse en la primera llamada y newTokenResponse en la segunda
            _mockHttpMessageHandler.Protected()
                .SetupSequence<Task<HttpResponseMessage>>(
                   "SendAsync",
                   ItExpr.Is<HttpRequestMessage>(req =>
                       req.Method == HttpMethod.Post &&
                       req.RequestUri.AbsolutePath.EndsWith("/token")
                   ),
                   ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(initialTokenResponse)),
                })
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(newTokenResponse)),
                });

            // Act
            var token1 = await _authenticationService.GetTokenAsync();

            // Esperar a que el token expire
            await Task.Delay(1500);

            var token2 = await _authenticationService.GetTokenAsync();

            // Assert
            Assert.AreEqual(initialToken, token1);
            Assert.AreEqual(newToken, token2);

            // Verificar que se hicieron dos llamadas al endpoint de token
            _mockHttpMessageHandler.Protected().Verify(
               "SendAsync",
               Times.Exactly(2), // Dos llamadas
               ItExpr.Is<HttpRequestMessage>(req =>
                   req.Method == HttpMethod.Post &&
                   req.RequestUri.AbsolutePath.EndsWith("/token")
               ),
               ItExpr.IsAny<CancellationToken>()
            );
        }
    }
}
