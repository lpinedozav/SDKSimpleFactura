using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Models.Request;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Enum;
using Newtonsoft.Json;
using SDKSimpleFactura;
using static SDKSimpleFactura.Enum.TipoDTE;
using SDKSimpleFactura.Models.Response;
namespace SDKSimpleFacturaTests
{
    [TestClass]
    public class ProveedoresServiceTests
    {
        private SimpleFacturaClient? _simpleFacturaClient;
        private IProveedoresService? _proveedoresService;
        [TestInitialize]
        public void Setup()
        {
            _simpleFacturaClient = new SimpleFacturaClient();
            _proveedoresService = _simpleFacturaClient.Proveedores;
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
            //Act
            var result = await _proveedoresService.ListadoDtesRecibidosAsync(request);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status,200);
            Assert.IsTrue(result.Data.Count >= 0);
            Assert.AreEqual(result.Message, $"Lista de Dtes Recibidos ({result.Data.Count})");
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task ListadoDtesRecibidosAsync_ReturnsError_WhenApiCallIsFail()
        {
            //Arrange
            var request = new ListaDteRequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6"
                },
                Ambiente = (Ambiente.AmbienteEnum)1
            };
            //Act
            var result = await _proveedoresService.ListadoDtesRecibidosAsync(request);
            //Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<bool>>(result.Message);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status,400);
            Assert.IsNull(response.Message);
            Assert.IsFalse(response.Data);
            CollectionAssert.Contains(response.Errors, "Si no se envían filtros de fecha, debe tener al menos un folio");
        }
        [TestMethod]
        public async Task ObtenerXmlAsync_ReturnsOkResult_WhenApiCallIsSuccessfully()
        {
            //Arrange
            var request = new ListaDteRequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    RutContribuyente = "77266449-4"
                },
                Ambiente = (Ambiente.AmbienteEnum)1,
                Folio = 2696,
                CodigoTipoDte = (DTEType)33
            };
            //Act
            var result = await _proveedoresService.ObtenerXmlAsync(request);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, 200);
            Assert.AreEqual(result.Message, "Exito");
            Assert.IsNotNull(result.Data);
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task ObtenerXmlAsync_ReturnsError_WhenApiCallIsFail()
        {
            //Arrange
            var request = new ListaDteRequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    RutContribuyente = "77266449-4"
                },
                Ambiente = (Ambiente.AmbienteEnum)1
            };
            //Act
            var result = await _proveedoresService.ObtenerXmlAsync(request);
            //Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<string>>(result.Message);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, 500);
            Assert.AreEqual(response.Data, "Error al obtener dtes recibidos desde api");
            Assert.IsNull(response.Message);
            CollectionAssert.Contains(response.Errors, "Folio debe tener un valor");
        }
        [TestMethod]
        public async Task ObtenerPDFAsync_ReturnsOkResult_WhenApiCallIsSuccessfully()
        {
            //Arrange
            var request = new ListaDteRequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    RutContribuyente = "76269769-6"
                },
                Ambiente = 0,
                Folio = 2232,
                CodigoTipoDte = (DTEType)33

            };
            //Act
            var result = await _proveedoresService.ObtenerPDFAsync(request);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, 200);
            Assert.IsNotNull(result.Data);
            Assert.IsInstanceOfType(result.Data, typeof(byte[]));
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task ObtenerPDFAsync_ReturnsError_WhenApiCallIsFail()
        {
            //Arrange
            var request = new ListaDteRequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    RutContribuyente = "76269769-6"
                },
                Ambiente = (Ambiente.AmbienteEnum)1
            };
            //Act
            var result = await _proveedoresService.ObtenerPDFAsync(request);
            //Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<string>>(result.Message);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, 500);
            Assert.AreEqual(response.Data, "Error al obtener dtes recibidos desde api");
            Assert.IsNull(response.Message);
            CollectionAssert.Contains(response.Errors, "Folio debe tener un valor");
        }
        [TestMethod]
        public async Task ConciliarRecibidosAsync_ReturnsOkResult_WhenApiCallIsSuccessfully()
        {
            //Arrange
            var request = new Credenciales
            {
                RutEmisor = "76269769-6"
            };
            //Act
            var result = await _proveedoresService.ConciliarRecibidosAsync(request,5,2024);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, 200);
            Assert.AreEqual(result.Message, "Los registros fueron actualizados según lo informado por el SII.");
            Assert.AreEqual(result.Data, "Los registros fueron actualizados según lo informado por el SII.");
            Assert.IsNull (result.Errors);
        }
        [TestMethod]
        public async Task ConciliarRecibidosAsync_ReturnsError_WhenApiCallIsSuccessfully()
        {
            //Arrange
            var request = new Credenciales
            {
                //RutEmisor = "76269769-6"
            };
            //Act
            var result = await _proveedoresService.ConciliarRecibidosAsync(request, 5, 2024);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, 500);
            Assert.IsTrue(result.Message.Contains("Rut de emisor vacio"));
            Assert.IsNull(result.Data);
            Assert.IsNull(result.Errors);
        }
    }
}
