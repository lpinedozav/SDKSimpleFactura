using Newtonsoft.Json;
using SDKSimpleFactura;
using SDKSimpleFactura.Helpers;
using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Models;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.Productos;

namespace SDKSimpleFacturaTests
{
    [TestClass]
    public class ProductosServiceTests
    {
        private SimpleFacturaClient? _simpleFacturaClient;
        private IProductosService? _productoService;
        [TestInitialize]
        public void Setup()
        {
            string username = Configuracion.Usuario;
            string password = Configuracion.Contrasena;
            _simpleFacturaClient = new SimpleFacturaClient(username, password);
            _productoService = _simpleFacturaClient.Productos;
        }
        [TestMethod]
        public async Task AgregarProductosAsync_ReturnsOkResult_WhenApiCallIsSuccessfully()
        {
            //Arrange
            var name = StringHelper.GenerateRandomString(6);
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
                        Nombre = name, 
                        CodigoBarra = name, 
                        Precio = 50,
                        UnidadMedida = "un",
                        Exento = false,
                        TieneImpuestos = false,
                        Impuestos = [0]
                    }
                }
            };
            //Act
            var result = await _productoService.AgregarProductosAsync(request);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, 200);
            Assert.AreEqual(result.Message, "Nuevos Productos");
            Assert.IsTrue(result.Data.Count>0);
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
                        Nombre = "Goma 901",
                        CodigoBarra = "goma901",
                        Precio = 50,
                        UnidadMedida = "un",
                        Exento = false,
                        TieneImpuestos = false,
                        Impuestos = [0]
                    }
                }
            };
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
            //Act
            var result = await _productoService.ListarProductosAsync(request);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, 200);
            Assert.AreEqual(result.Message, "Productos");
            Assert.IsTrue(result.Data.Count>=0);
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task ListarProductosAsync_ReturnsBadRequest_WhenApiCallIsFail()
        {
            //Arrange
            var request = new Credenciales
            {
                //RutEmisor = "76269769-6",
                NombreSucursal = "Casa Matriz"
            };
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
