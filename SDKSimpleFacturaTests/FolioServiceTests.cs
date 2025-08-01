﻿using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura;
using SDKSimpleFactura.Models.Request;
using Newtonsoft.Json;
using SDKSimpleFactura.Models.Facturacion;
using static SDKSimpleFactura.Enum.TipoDTE;
using SDKSimpleFactura.Models.Response;
using SDKSimpleFacturaTests.Utilidades;

namespace SDKSimpleFacturaTests
{
    [TestClass]
    public class FolioServiceTests
    {
        private SimpleFacturaClient? _simpleFacturaClient;
        private IFolioService? _folioService;

        [TestInitialize]
        public void Setup()
        {
            var serviceProvider = TestDependencyInjectionConfig.ConfigureTestServices();
            _simpleFacturaClient = new SimpleFacturaClient(serviceProvider);
            _folioService = _simpleFacturaClient.Folio;
        }
        [TestMethod]
        public async Task ConsultaFoliosDisponiblesAsync_ReturnsOkResult_WhenApiCallIsSuccessfully()
        {
            //Arrange
            var request = new SolicitudFoliosRequest
            {
                RutEmpresa = "76269769-6",
                TipoDTE = 33,
                Ambiente = 0
            };
            //Act
            var result = await _folioService.ConsultaFoliosDisponiblesAsync(request);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, 200);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(result.Message, $"El rut 76269769-6 tiene {result.Data} folios disponibles del tipo 33");
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task ConsultaFoliosDisponiblesAsync_ReturnsError_WhenApiCallIsFail()
        {
            //Arrange
            var request = new SolicitudFoliosRequest
            {
                RutEmpresa = "76269769-6",
                Ambiente = 0
            };
            //Act
            var result = await _folioService.ConsultaFoliosDisponiblesAsync(request);
            //Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<string>>(result.Message);
            Assert.AreEqual(response.Status, 400);
            Assert.AreEqual(response.Data, "Falta tipo de codigo DTE");
            Assert.AreEqual(response.Message, "Error al consultar folios disponibles directamente al SII");
            Assert.IsNull(response.Errors);
        }
        [TestMethod]
        public async Task SolicitarFoliosAsync_ReturnsOkResult_WhenFolioIsRequestedSuccessfully()
        {
            int maxIntentos = 3;
            int intentoActual = 0;
            bool exito = false;
            Exception ultimaExcepcion = null;

            while (intentoActual < maxIntentos && !exito)
            {
                intentoActual++;
                try
                {
                    // Arrange
                    var request = new FolioRequest
                    {
                        Credenciales = new Credenciales
                        {
                            RutEmisor = "76269769-6",
                            NombreSucursal = "Casa Matriz"
                        },
                        Cantidad = 1,
                        CodigoTipoDte = (DTEType)33
                    };
                    // Act
                    var result = await _folioService.SolicitarFoliosAsync(request);
                    // Assert
                    Assert.IsNotNull(result);
                    Assert.AreEqual(200, result.Status);
                    Assert.IsNotNull(result.Data);
                    Assert.AreEqual(33, result.Data.CodigoSii);
                    Assert.AreEqual($"El timbraje de tipo FACTURA ELECTRONICA con rangos desde {result.Data.Desde} hasta {result.Data.Hasta} fue ingresado correctamente", result.Message);
                    Assert.IsNull(result.Errors);

                    exito = true;
                }
                catch (Exception ex)
                {
                    ultimaExcepcion = ex;
                    if (intentoActual < maxIntentos)
                    {
                        await Task.Delay(1000);
                    }
                }
            }

            if (!exito)
            {
                Assert.Fail($"La prueba falló después de {maxIntentos} intentos. Último error: {ultimaExcepcion?.Message}");
            }
        }
        [TestMethod]
        public async Task SolicitarFoliosAsync_ReturnsError_WhenApiCallIsFail()
        {
            //Arrange
            var request = new FolioRequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    NombreSucursal = "Casa Matriz"
                },
                Cantidad = 1,
                //CodigoTipoDte = (DTEType)33
            };
            //Act
            var result = await _folioService.SolicitarFoliosAsync(request);
            //Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<bool>>(result.Message);
            Assert.AreEqual(response.Status, 400);
            Assert.IsFalse(response.Data);
            Assert.IsNull(response.Message);
            CollectionAssert.Contains(response.Errors, "Codigo tipo dte no válido");
        }
        [TestMethod]
        public async Task ConsultarFoliosAsync_ReturnsOkResult_WhenApiCallIsSuccessfully()
        {
            //Arrange
            var request = new FolioRequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    NombreSucursal = "Casa Matriz"
                },
                CodigoTipoDte = null,
                Ambiente = 0
            };
            //Act
            var result = await _folioService.ConsultarFoliosAsync(request);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, 200);
            Assert.AreEqual(result.Message, "");
            Assert.IsTrue(result.Data.Count >= 0);
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task ConsultarFoliosAsync_ReturnsError_WhenApiCallIsFail()
        {
            //Arrange
            var request = new FolioRequest
            {
                Credenciales = new Credenciales
                {
                    //RutEmisor = "76269769-6",
                    NombreSucursal = "Casa Matriz"
                },
                CodigoTipoDte = null,
                Ambiente = 0
            };
            //Act
            var result = await _folioService.ConsultarFoliosAsync(request);
            //Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<bool>>(result.Message);
            Assert.AreEqual(response.Status, 400);
            Assert.IsFalse(response.Data);
            Assert.IsNull(response.Message);
            CollectionAssert.Contains(response.Errors, "Rut de emisor vacio");
        }
        [TestMethod]
        public async Task FoliosSinUsoAsync_ReturnsOkResult_WhenApiCallIsSuccessfully()
        {
            //Arrange
            var request = new SolicitudFoliosRequest
            {
                RutEmpresa = "76269769-6",
                TipoDTE = 33,
                Ambiente = 0
            };
            //Act
            var result = await _folioService.FoliosSinUsoAsync(request);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, 200);
            Assert.AreEqual(result.Message, "Folios disponibles sin uso");
            Assert.IsTrue(result.Data.Count >= 0);
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task FoliosSinUsoAsync_ReturnsError_WhenApiCallIsFail()
        {
            //Arrange
            var request = new SolicitudFoliosRequest
            {
                RutEmpresa = "76269769-6",
                //TipoDTE = 33,
                Ambiente = 0
            };
            //Act
            var result = await _folioService.FoliosSinUsoAsync(request);
            //Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<string>>(result.Message);
            Assert.AreEqual(response.Status, 400);
            Assert.AreEqual(response.Message, "Error al consultar folios disponibles directamente al SII");
            Assert.AreEqual(response.Data, "Falta tipo de codigo DTE");
            Assert.IsNull(response.Errors);
        }
    }
}
