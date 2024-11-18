using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.Request;
using Newtonsoft.Json;
using SDKSimpleFactura.Models.Response;

namespace SDKSimpleFacturaTests
{
    [TestClass]
    public class BoletasHonorariosServiceTests
    {
        private SimpleFacturaClient? _simpleFacturaClient;
        private IBoletasHonorariosService? _boletasHonorarioService;
        [TestInitialize]
        public void Setup()
        {
            string username = Configuracion.Usuario;
            string password = Configuracion.Contrasena;
            _simpleFacturaClient = new SimpleFacturaClient(username, password);
            _boletasHonorarioService = _simpleFacturaClient.BoletasHonorariosService;
        }
        [TestMethod]
        public async Task ObtenerPDFBHEEmitidaAsync_RetunsOkResult_WhenApiCallIsSuccessfully()
        {
            //Arrange
            var request = new BHERequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6"
                },
                Folio = 15
            };
            // Act
            var result = await _boletasHonorarioService.ObtenerPDFBHEEmitidaAsync(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.Status);
            Assert.IsNotNull(result.Data);
            Assert.IsInstanceOfType(result.Data, typeof(byte[]));
            Assert.IsNull(result.Message);
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task ObtenerPDFBHEEmitidaAsync_RetunsError_WhenApiCallIsFail()
        {
            //Arrange
            var request = new BHERequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6"
                },
                //Folio = 15
            };
            // Act
            var result = await _boletasHonorarioService.ObtenerPDFBHEEmitidaAsync(request);

            // Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<string>>(result.Message);
            Assert.AreEqual(400, response.Status);
            Assert.AreEqual(response.Data, "Error al validar credenciales");
            Assert.IsNull(response.Message);
            CollectionAssert.Contains(response.Errors, "Folio no puede ir vacío");
        }
        [TestMethod]
        public async Task ListadoBHEEmitidasAsync_ReturnsOkResult_WhenApiCallIsSuccessfully()
        {
            //Arrange
            var request = new ListaBHERequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    NombreSucursal = "Casa Matriz"
                },
                Folio = null,
                Desde = DateTime.Parse("2024-09-03"),
                Hasta = DateTime.Parse("2024-11-11")
            };
            //Act
            var result = await _boletasHonorarioService.ListadoBHEEmitidasAsync(request);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, 200);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(result.Message, $"Lista de Bhes ({result.Data.Count})");
            Assert.IsTrue(result.Data.Count >= 0);
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task ListadoBHEEmitidasAsync_ReturnsError_WhenApiCallIsFail()
        {
            //Arrange
            var request = new ListaBHERequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    NombreSucursal = "Casa Matriz"
                },
                Folio = null
            };
            //Act
            var result = await _boletasHonorarioService.ListadoBHEEmitidasAsync(request);
            //Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<bool>>(result.Message);
            Assert.AreEqual(response.Status, 400);
            Assert.IsNull(response.Message);
            Assert.IsFalse(response.Data);
            CollectionAssert.Contains(response.Errors, "Si no se envían filtros de fecha, debe tener al menos un folio");
        }

        [TestMethod]
        public async Task ObtenerPDFBHERecibidosAsync_RetunsOkResult_WhenApiCallIsSuccessfully()
        {
            //Arrange
            var request = new BHERequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    RutContribuyente = "26671002-K"
                },
                Folio = 2
            };
            // Act
            var result = await _boletasHonorarioService.ObtenerPDFBHERecibidosAsync(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.Status);
            Assert.IsNotNull(result.Data);
            Assert.IsInstanceOfType(result.Data, typeof(byte[]));
            Assert.IsNull(result.Message);
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task ObtenerPDFBHERecibidosAsync_RetunsError_WhenApiCallIsFail()
        {
            //Arrange
            var request = new BHERequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    RutContribuyente = "26429782-6"
                },
                //Folio = 15
            };
            // Act
            var result = await _boletasHonorarioService.ObtenerPDFBHERecibidosAsync(request);

            // Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<string>>(result.Message);
            Assert.AreEqual(400, response.Status);
            Assert.AreEqual(response.Data, "Error al validar credenciales");
            Assert.IsNull(response.Message);
            CollectionAssert.Contains(response.Errors, "Folio no puede ir vacío");
        }
        [TestMethod]
        public async Task ListadoBHERecibidosAsync_ReturnsOkResult_WhenApiCallIsSuccessfully()
        {
            //Arrange
            var request = new ListaBHERequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    NombreSucursal = "Casa Matriz"
                },
                Folio = null,
                Desde = DateTime.Parse("2024-09-03"),
                Hasta = DateTime.Parse("2024-11-11")
            };
            //Act
            var result = await _boletasHonorarioService.ListadoBHERecibidosAsync(request);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, 200);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(result.Message, $"Lista de Bhes ({result.Data.Count})");
            Assert.IsTrue(result.Data.Count >= 0);
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task ListadoBHERecibidosAsync_ReturnsError_WhenApiCallIsFail()
        {
            //Arrange
            var request = new ListaBHERequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    NombreSucursal = "Casa Matriz"
                },
                Folio = null
            };
            //Act
            var result = await _boletasHonorarioService.ListadoBHERecibidosAsync(request);
            //Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<bool>>(result.Message);
            Assert.AreEqual(response.Status, 400);
            Assert.IsNull(response.Message);
            Assert.IsFalse(response.Data);
            CollectionAssert.Contains(response.Errors, "Si no se envían filtros de fecha, debe tener al menos un folio");
        }

    }
}
