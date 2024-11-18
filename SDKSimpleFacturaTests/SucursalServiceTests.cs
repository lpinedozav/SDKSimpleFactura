using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura;
using SDKSimpleFactura.Models.Facturacion;
using Newtonsoft.Json;
using SDKSimpleFactura.Models.Response;

namespace SDKSimpleFacturaTests
{
    [TestClass]
    public class SucursalServiceTests
    {
        private SimpleFacturaClient? _simpleFacturaClient;
        private ISucursalService? _sucursalService;
        [TestInitialize]
        public void Setup()
        {
            string username = Configuracion.Usuario;
            string password = Configuracion.Contrasena;
            _simpleFacturaClient = new SimpleFacturaClient(username, password);
            _sucursalService = _simpleFacturaClient.Sucursal;
        }
        [TestMethod]
        public async Task ListadoSucursalesAsync_ReturnsOkResult_WhenApiCallIsSuccessfully()
        {
            //Arrange
            var request = new Credenciales
            {
                RutEmisor = "76269769-6"
            };
            //Act
            var result = await _sucursalService.ListadoSucursalesAsync(request);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, 200);
            Assert.AreEqual(result.Message, "Sucursales");
            Assert.IsTrue(result.Data.Count >= 0);
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task ListadoSucursalesAsync_ReturnsError_WhenApiCallIsFail()
        {
            //Arrange
            var request = new Credenciales
            {
                //RutEmisor = "76269769-6"
            };
            //Act
            var result = await _sucursalService.ListadoSucursalesAsync(request);
            //Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<bool>>(result.Message);
            Assert.AreEqual(response.Status, 400);
            Assert.IsFalse(response.Data);
            Assert.IsNull(response.Message);
            CollectionAssert.Contains(response.Errors, "Rut de emisor vacio");
        }
    }
}
