using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura;
using SDKSimpleFactura.Models.Facturacion;
using Newtonsoft.Json;
using SDKSimpleFactura.Models.Response;

namespace SDKSimpleFacturaTests
{
    [TestClass]
    public class ConfiguracionServiceTests
    {
        private SimpleFacturaClient? _simpleFacturaClient;
        private IConfiguracionService? _configuracionService;
        [TestInitialize]
        public void Setup()
        {
            string username = Configuracion.Usuario;
            string password = Configuracion.Contrasena;
            _simpleFacturaClient = new SimpleFacturaClient(username, password);
            _configuracionService = _simpleFacturaClient.Configuracion;
        }
        [TestMethod]
        public async Task DatosEmpresaAsync_ReturnsOkResult_WhenApiCallIsSuccessfully()
        {
            //Arrange
            var request = new Credenciales
            {
                RutEmisor = "76269769-6"
            };
            //Act
            var result = await _configuracionService.DatosEmpresaAsync(request);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, 200);
            Assert.IsNotNull(result.Data);
            Assert.IsNull(result.Message);
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task DatosEmpresaAsync_ReturnsError_WhenApiCallIsFail()
        {
            //Arrange
            var request = new Credenciales
            {
                //RutEmisor = "76269769-6"
            };
            //Act
            var result = await _configuracionService.DatosEmpresaAsync(request);
            //Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<string>>(result.Message);
            Assert.AreEqual(response.Status, 500);
            Assert.AreEqual(response.Data, "Error al obtener emisor desde api");
            Assert.IsNull(response.Message);
            CollectionAssert.Contains(response.Errors, "Rut de emisor vacio");
        }
    }
}
