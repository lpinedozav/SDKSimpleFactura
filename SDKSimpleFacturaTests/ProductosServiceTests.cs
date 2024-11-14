using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Models;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.Productos;
using SDKSimpleFactura.Services;
using System.Net;
using System.Text;

namespace SDKSimpleFacturaTests
{
    [TestClass]
    public class ProductosServiceTests
    {
        private Mock<HttpMessageHandler>? _httpMessageHandlerMock;
        private HttpClient? _httpClient;
        private IApiService? _apiService;
        private IProductosService? _productoService;
        [TestInitialize]
        public void Setup()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_httpMessageHandlerMock.Object)
            {
                BaseAddress = new System.Uri("http://localhost/")
            };
            _apiService = new ApiService(_httpClient);
            _productoService = new ProductosService(_apiService);
        }
        [TestMethod]
        public async Task AgregarProductosAsync_ReturnsOkResult_WhenApiCallIsSuccessfully()
        {
            //Arrange
            var request = new DatoExternoRequest
            {
                Credenciales = new Credenciales 
                {
                    RutEmisor = "76269769-6", 
                    NombreSucursal = "Casa Matriz" 
                },
                Productos = new List<NuevoProductoExternoRequest>
                {
                    new NuevoProductoExternoRequest 
                    {
                        Nombre = "Goma 805", 
                        CodigoBarra = "goma805", 
                        Precio = 50 
                    }
                }
            };
            var fakeResponse = new Response<List<ProductoEnt>>
            {
                Status = 200,
                Message = "Nuevos Productos",
                Data = new List<ProductoEnt>
                {
                    new ProductoEnt 
                    { 
                        ProductoId = Guid.NewGuid(),
                        Nombre = "Goma 805",
                        Precio = 50 
                    }
                },
                Errors = null
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
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json")
                });
            //Act
            var result = await _productoService.AgregarProductosAsync(request);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, 200);
            Assert.AreEqual(result.Message, "Nuevos Productos");
            Assert.AreEqual(result.Data.First().Nombre, "Goma 805");
            Assert.IsNull(result.Errors);

        }
        [TestMethod]
        public async Task AgregarProductosAsync_ReturnsBadRequest_WhenApiCallIsFail()
        {
            //Arrange
            var request = new DatoExternoRequest
            {
                Credenciales = new Credenciales 
                { 
                    NombreSucursal = "Casa Matriz" 
                },
                Productos = new List<NuevoProductoExternoRequest>
                {
                    new NuevoProductoExternoRequest 
                    { 
                        Nombre = "Goma 805", 
                        CodigoBarra = "goma805", 
                        Precio = 50 
                    }
                }
            };
            var fakeResponse = new Response<bool>
            {
                Status = 400,
                Message = null,
                Data = false,
                Errors = new[] { "Rut de emisor vacio" }
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
            var result = await _productoService.AgregarProductosAsync(request);
            //Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<bool>>(result.Message);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, 400);
            Assert.IsNull(response.Message);
            Assert.IsFalse(response.Data);
            CollectionAssert.Contains(response.Errors, "Rut de emisor vacio");
        }
        [TestMethod]
        public async Task ListarProductosAsync_ReturnsOkResult_WhenApiCallIsSuccessfully()
        {
            //Arrange
            var request = new Credenciales
            {
                RutEmisor = "76269769-6",
                NombreSucursal = "Casa Matriz"
            };
            var fakeResponse = new Response<List<ProductoExternoEnt>>
            {
                Status = 200,
                Message = "Productos",
                Data = new List<ProductoExternoEnt>
                {
                    new ProductoExternoEnt
                    {
                        ProductoId = Guid.NewGuid(),
                        Nombre = "Harina Mariposa",
                        Precio = 2300,
                        Exento = false,
                        Impuestos = new List<ImpuestoProductoExternoEnt>
                        {
                            new ImpuestoProductoExternoEnt
                            {
                                CodigoSii = 271,
                                NombreImp = "Bebidas Azucaradas",
                                Tasa = 18
                            }
                        }
                    }
                },
                Errors = null
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
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json")
                });
            //Act
            var result = await _productoService.ListarProductosAsync(request);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, 200);
            Assert.AreEqual(result.Message, "Productos");
            Assert.AreEqual(result.Data.First().Nombre, "Harina Mariposa");
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task ListarProductosAsync_ReturnsBadRequest_WhenApiCallIsFail()
        {
            //Arrange
            var request = new Credenciales
            {
                RutEmisor = "76269769-6",
                NombreSucursal = "Casa Matriz"
            };
            var fakeResponse = new Response<bool>
            {
                Status = 400,
                Message = null,
                Data = false,
                Errors = new[] { "Rut de emisor vacio" }
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
            var result = await _productoService.ListarProductosAsync(request);
            //Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<bool>>(result.Message);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, 400);
            Assert.IsNull(response.Message);
            Assert.IsFalse(response.Data);
            CollectionAssert.Contains(response.Errors, "Rut de emisor vacio");
        }
    }
}
