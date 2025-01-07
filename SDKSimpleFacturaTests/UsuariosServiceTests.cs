using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.Response;
using Newtonsoft.Json;
using SDKSimpleFactura.Services;
namespace SDKSimpleFacturaTests
{
    [TestClass]
    public class UsuariosServiceTests
    {
        private SimpleFacturaClient? _simpleFacturaClient;
        private IUsuariosService? _usuariosService;
        [TestInitialize]
        public void Setup()
        {
            _simpleFacturaClient = new SimpleFacturaClient();
            _usuariosService = _simpleFacturaClient.Usuarios;
        }
        [TestMethod]
        public async Task ListarUsuariosAsync_ReturnsOkResult_WhenApiCallIsSuccessfully()
        {
            //Arrange
            var request = new Credenciales
            {
                RutEmisor = "76269769-6"
            };
            //Act
            var result = await _usuariosService.ListarUsuariosAsync(request);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, 200);
            Assert.IsNotNull(result.Data);
            Assert.IsInstanceOfType(result.Data, typeof(List<UsuarioEnt>));
            Assert.AreEqual(result.Message, "Usuarios");
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
            var result = await _usuariosService.ListarUsuariosAsync(request);
            //Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<bool>>(result.Message);
            Assert.AreEqual(response.Status, 500);
            Assert.IsFalse(response.Data);
            Assert.AreEqual(response.Message, "Error al obtener usuarios de la empresa.");
            CollectionAssert.Contains(response.Errors, "Object reference not set to an instance of an object.");
        }
    }
}
