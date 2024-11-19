using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura;
using SDKSimpleFactura.Models.Facturacion;
using Newtonsoft.Json;
using SDKSimpleFactura.Models.Request;
using SDKSimpleFactura.Models.Response;
namespace SDKSimpleFacturaTests
{
    [TestClass]
    public class ClientesServiceTests
    {
        private SimpleFacturaClient? _simpleFacturaClient;
        private IClientesService? _clientesService;
        [TestInitialize]
        public void Setup()
        {
            string username = Configuracion.Usuario;
            string password = Configuracion.Contrasena;
            _simpleFacturaClient = new SimpleFacturaClient(username, password);
            _clientesService = _simpleFacturaClient.Clientes;
        }
        [TestMethod]
        public async Task AgregarClientesAsync_ReturnsOkResult_WhenApiCallIsSuccessfully()
        {
            //Arrange
            var request = new DatoExternoRequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    NombreSucursal = "Matriz"
                },
                Clientes = new List<NuevoReceptorExternoRequest>
                {
                    new NuevoReceptorExternoRequest
                    {
                        Rut = "57681892-0",
                        RazonSocial = "Cliente Test 1",
                        Giro = "Giro 1",
                        DirPart = "direccion 1",
                        DirFact = "direccion 1",
                        CorreoPar = "correo 1",
                        CorreoFact = "correo 1",
                        Ciudad = "Ciudad 1",
                        Comuna = "Comuna 1"
                    }
                }
            };
            //Act
            var result = await _clientesService.AgregarClientesAsync(request);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, 200);
            Assert.AreEqual(result.Message, "Nuevos Clientes");
            Assert.IsTrue(result.Data.Count == 1);
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task AgregarClientesAsync_ReturnsError_WhenApiCallIsFail()
        {
            //Arrange
            var request = new DatoExternoRequest
            {
                Credenciales = new Credenciales
                {
                    NombreSucursal = "Matriz"
                },
                Clientes = new List<NuevoReceptorExternoRequest>
                {
                    new NuevoReceptorExternoRequest
                    {
                        Rut = "57681892-0",
                        RazonSocial = "Cliente Test 1",
                        Giro = "Giro 1",
                        DirPart = "direccion 1",
                        DirFact = "direccion 1",
                        CorreoPar = "correo 1",
                        CorreoFact = "correo 1",
                        Ciudad = "Ciudad 1",
                        Comuna = "Comuna 1"
                    }
                }
            };
            //Act
            var result = await _clientesService.AgregarClientesAsync(request);
            //Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<bool>>(result.Message);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, 400);
            Assert.IsFalse(response.Data);
            Assert.IsNull(response.Message);
            CollectionAssert.Contains(response.Errors, "Rut de emisor vacio");
        }
        [TestMethod]
        public async Task ListarClientesAsync_ReturnsOkResult_WhenAPiCallIsSuccessfully()
        {
            //Arrange
            var request = new Credenciales
            {
                RutEmisor = "76269769-6"
            };
            //Act
            var result = await _clientesService.ListarClientesAsync(request);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, 200);
            Assert.AreEqual(result.Message, "Clientes");
            Assert.IsTrue(result.Data.Count > 0);
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task ListarClientesAsync_ReturnsError_WhenApiCallIsFail()
        {
            //Arrange
            var request = new Credenciales
            {
                //RutEmisor = "76269769-6"
            };
            //Act
            var result = await _clientesService.ListarClientesAsync(request);
            //Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<bool>>(result.Message);
            Assert.AreEqual(response.Status, 400);
            Assert.IsNull(response.Message);
            Assert.IsFalse(response.Data);
            CollectionAssert.Contains(response.Errors, "Rut de emisor vacio");
        }
    }
}
