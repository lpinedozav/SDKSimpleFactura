using Moq;
using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Models.Proveedores;
using SDKSimpleFactura.Services;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Enum;
using SDKSimpleFactura.Models;
using Moq.Protected;
using Newtonsoft.Json;
using System.Net;
using System.Text;
namespace SDKSimpleFacturaTests
{
    [TestClass]
    public class ProveedoresServiceTests
    {
        private Mock<HttpMessageHandler>? _httpMessageHandlerMock;
        private HttpClient? _httpClient;
        private IApiService? _apiService;
        private IProveedoresService? _proveedoresService;
        [TestInitialize]
        public void Setup()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_httpMessageHandlerMock.Object)
            {
                BaseAddress = new System.Uri("http://localhost/")
            };
            _apiService = new ApiService(_httpClient);
            _proveedoresService = new ProveedoresService(_apiService);
        }
        [TestMethod]
        public async Task AcuseReciboAsync_ReturnsOkResult()
        {

        }
        [TestMethod]
        public async Task AcuseReciboAsync_ReturnsBadRequest_WhenApiCallIsFail()
        {
            //Arrange
            var request = new AcuseReciboExternoRequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    RutContribuyente = "76372100-0",
                    NombreSucursal = "Casa Matriz"
                },
                DteReferenciadoExterno = new DteReferenciadoExterno
                {
                    Folio = 373,
                    CodigoTipoDte = 33,
                    Ambiente = 0
                },
                Respuesta = (ResponseType)5,
                TipoRechazo = (RejectionType)1,
                Comentario = "test"
            };
            var fakeResponse = new Response<bool>
            {
                Status = 400,
                Message = null,
                Data = false,
                Errors = new[] { "El documento recibido del tipo Factura Electrónica folio 373 del proveedor con rut 76372100-0 no fue encontradoen el ambiente Certificación" }
            };
            var jsonResponse = JsonConvert.SerializeObject(fakeResponse);

            _httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json")
                });
            //Act
            var result = await _proveedoresService.AcuseReciboAsync(request);
            //Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<bool>>(result.Message);
            Assert.AreEqual(response.Status, 400);
            Assert.IsFalse(response.Data);
            Assert.IsNull(response.Message);
            CollectionAssert.Contains(response.Errors, "El documento recibido del tipo Factura Electrónica folio 373 del proveedor con rut 76372100-0 no fue encontradoen el ambiente Certificación");
        }
        [TestMethod]
        public async Task ListadoDtesRecibidosAsync_ReturnsOkResult_WhenApiCallIsSuccessfully()
        {
            //Arrange
            var request = new ListaDteRequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6"
                },
                Ambiente = (Ambiente.AmbienteEnum)1,
                Folio = null,
                CodigoTipoDte = null,
                Desde = DateTime.Parse("2024-04-01"),
                Hasta = DateTime.Parse("2024-04-30")
            };
            var fakeResponse = new Response<List<Dte>>
            {
                Status = 200,
                Message = "Lista de Dtes Recibidos (7)",
                
            };
            //Act
            var result = await _proveedoresService.ListadoDtesRecibidosAsync(request);
            //Assert
        }
    }
}
