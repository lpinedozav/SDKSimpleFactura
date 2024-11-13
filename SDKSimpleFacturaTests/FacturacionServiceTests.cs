using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using SDKSimpleFactura.Enum;
using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Models;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Services;
using System.Net;
using System.Text;
using static SDKSimpleFactura.Enum.TipoDTE;

namespace SDKSimpleFacturaTests
{
    [TestClass]
    public class FacturacionServiceTests
    {
        private Mock<HttpMessageHandler>? _httpMessageHandlerMock;
        private HttpClient? _httpClient;
        private IApiService? _apiService;
        private IFacturacionService? _facturacionService;
        

        [TestInitialize]
        public void Setup()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_httpMessageHandlerMock.Object)
            {
                BaseAddress = new System.Uri("http://localhost/")
            };
            _apiService = new ApiService(_httpClient);
            _facturacionService = new FacturacionService(_apiService);
        }
        [TestMethod]
        public async Task ObtenerPdfDteAsync_RetunsOkResult_WhenPDFIsSentSucessfully()
        {
            //Arrange
            var solicitudPDF = new SolicitudDte
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    NombreSucursal = "Casa Matriz"
                },
                DteReferenciadoExterno = new DteReferenciadoExterno
                {
                    Folio = 4117,
                    CodigoTipoDte = 33,
                    Ambiente = 0
                }
            };
            var fakePdfBytes = new byte[] { 1, 2, 3, 4 };

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
                    Content = new ByteArrayContent(fakePdfBytes)
                });

            // Act
            var result = await _facturacionService.ObtenerPdfDteAsync(solicitudPDF);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.Status);
            Assert.IsNotNull(result.Data);
            CollectionAssert.AreEqual(fakePdfBytes, result.Data);
        }
        [TestMethod]
        public async Task ObtenerPdfDteAsync_ReturnsError_WhenApiReturnsFailure()
        {
            // Arrange
            var solicitudPDF = new SolicitudDte
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    NombreSucursal = "Casa Matriz"
                },
                DteReferenciadoExterno = new DteReferenciadoExterno
                {
                    Folio = 4117,
                    CodigoTipoDte = 33,
                    Ambiente = 0
                }
            };

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
                    Content = new ByteArrayContent(new byte[] { })
                });

            // Act
            var result = await _facturacionService.ObtenerPdfDteAsync(solicitudPDF);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.Status);
            Assert.IsNull(result.Data);
            Assert.IsTrue(result.Message.Contains("Error en la peticion"));
        }
        [TestMethod]
        public async Task ObtenerTimbreDteAsync_ReturnsOkResult_WhenTimbreIsGeneratedSuccessfully()
        {
            // Arrange
            var solicitudTimbre = new SolicitudDte
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    NombreSucursal = "Casa Matriz"
                },
                DteReferenciadoExterno = new DteReferenciadoExterno
                {
                    Folio = 4117,
                    CodigoTipoDte = 33,
                    Ambiente = 0
                }
            };
            var response = new Response<string>
            {
                Status = 200,
                Message = "Timbre del DTE tipo FacturaElectronica con folio 2963 de la empresa 76269769-6",
                Data = "",
                Errors = null
            };
            var jsonResponse = Newtonsoft.Json.JsonConvert.SerializeObject(response);

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

            // Act
            var result = await _facturacionService.ObtenerTimbreDteAsync(solicitudTimbre);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.Status);
            Assert.AreEqual(response.Message, result.Message);
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task ObtenerTimbreDteAsync_ReturnsError_WhenApiReturnsFailure()
        {
            // Arrange
            var solicitudTimbre = new SolicitudDte
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    NombreSucursal = "Casa Matriz"
                },
                DteReferenciadoExterno = new DteReferenciadoExterno
                {
                    Folio = 296355,
                    CodigoTipoDte = 33,
                    Ambiente = 0
                }
            };

            var fakeErrorResponse = new Response<string>
            {
                Status = 500,
                Message = null,
                Data = "Error al obtener xml desde api",
                Errors = ["DTE no encontrado"]            
            };

            var jsonResponse = Newtonsoft.Json.JsonConvert.SerializeObject(fakeErrorResponse);

            _httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json")
                });

            // Act
            var result = await _facturacionService.ObtenerTimbreDteAsync(solicitudTimbre);
            // Assert
            Assert.IsNotNull(result);
            var objectResult = JsonConvert.DeserializeObject<Response<string>>(result.Message);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual(objectResult.Status, fakeErrorResponse.Status);
            Assert.AreEqual(objectResult.Message, fakeErrorResponse.Message);
            Assert.AreEqual(objectResult.Data, fakeErrorResponse.Data);
            CollectionAssert.AreEqual(objectResult.Errors, fakeErrorResponse.Errors);
        }
        [TestMethod]
        public async Task ObtenerXmlDteAsync_ReturnsOkResult_WhenXmlDteIsSentSuccessfully()
        {
            //Arrange
            var solicitudXml = new SolicitudDte
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                },
                DteReferenciadoExterno = new DteReferenciadoExterno
                {
                    Folio = 12553,
                    CodigoTipoDte = 39,
                    Ambiente = 0
                }
            };
            var fakePdfBytes = new byte[] { 1, 2, 3, 4 };

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
                    Content = new ByteArrayContent(fakePdfBytes)
                });
            //Act
            var result = await _facturacionService.ObtenerXmlDteAsync(solicitudXml);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.Status);
            Assert.IsNotNull(result.Data);
            CollectionAssert.AreEqual(fakePdfBytes, result.Data);
        }
        [TestMethod]
        public async Task ObtenerXmlDteAsync_ResturnsError_WhenApiReturnsFailure()
        {
            //Arrange
            var solicitudXml = new SolicitudDte();
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
                    Content = new ByteArrayContent(new byte[] { }) // Simula un cuerpo vacío
                });
            //Act
            var result = await _facturacionService.ObtenerXmlDteAsync(solicitudXml);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.Status);
            Assert.IsNull(result.Data);
            Assert.IsTrue(result.Message.Contains("Error en la peticion"));


        }
        [TestMethod]
        public async Task ObtenerSobreXmlDteAsync_ReturnsOkResult_WhenXmlSobreIsSentSuccessfully()
        {
            // Arrange
            var solicitudXmlSobre = new SolicitudDte
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    NombreSucursal = "Casa Matriz"
                },
                DteReferenciadoExterno = new DteReferenciadoExterno
                {
                    Folio = 4117,
                    CodigoTipoDte = 33,
                    Ambiente = 0
                }
            };
            var fakePdfBytes = new byte[] { 1, 2, 3, 4 };

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
                    Content = new ByteArrayContent(fakePdfBytes)
                });

            // Act
            var result = await _facturacionService.ObtenerSobreXmlDteAsync(solicitudXmlSobre, TipoSobreEnvio.AlReceptor);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.Status);
            Assert.IsNotNull(result.Data);
            CollectionAssert.AreEqual(fakePdfBytes, result.Data);
        }
        [TestMethod]
        public async Task ObtenerSobreXmlDteAsync_ReturnsError_WhenApiReturnsFailure()
        {
            // Arrange
            var solicitudXmlSobre = new SolicitudDte();

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
                    Content = new ByteArrayContent(new byte[] { })
                });

            // Act
            var result = await _facturacionService.ObtenerSobreXmlDteAsync(solicitudXmlSobre, TipoSobreEnvio.AlReceptor);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.Status);
            Assert.IsNull(result.Data);
            Assert.IsTrue(result.Message.Contains("Error en la peticion"));
        }
        [TestMethod]
        public async Task ObtenerDteAsync_ReturnsOkResult_WhenDteIsRetrievedSuccessfully()
        {
            // Arrange
            var solicitudDte = new SolicitudDte
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    NombreSucursal = "Casa Matriz"
                },
                DteReferenciadoExterno = new DteReferenciadoExterno
                {
                    Folio = 12553,
                    CodigoTipoDte = 39,
                    Ambiente = 0
                }
            };

            var response = new Response<Dte>
            {
                Status = 200,
                Message = "DTE encontrado",
                Data = new Dte
                {
                    Ambiente = "Certificación",
                    FolioReutilizado = "No",
                    Importado = "No",
                    CodigoSii = 39,
                    TipoDte = "Boleta Electrónica",
                    EstadoAcuse = "Pendiente",
                    EstadoSII = "Documento Aceptado con Reparos",
                    FechaDte = "2023-04-20",
                    FechaCreacion = "2023-04-20 17:22",
                    Folio = 12553,
                    RazonSocialReceptor = "Cliente en Marketplace",
                    RutReceptor = "66666666-6",
                    TrackId = 21356542,
                    Neto = 832,
                    Exento = 0,
                    Iva = 158,
                    IvaTerceros = 0,
                    IvaPropio = 0,
                    TotalImpuestosAdicionales = 0,
                    Total = 990,
                    Detalles = new List<DetalleDte>
            {
                new DetalleDte
                {
                    Nombre = "Alfajor",
                    Descripcion = "Sin Descripción",
                    Exento = "NO",
                    Precio = 990,
                    Cantidad = 1,
                    TotalImpuestos = 0,
                    Total = 990
                }
            },
                    Referencias = new List<ReferenciaDte>()
                },
                Errors = null
            };

            var jsonResponse = JsonConvert.SerializeObject(response);

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

            // Act
            var result = await _facturacionService.ObtenerDteAsync(solicitudDte);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.Status);
            Assert.AreEqual("DTE encontrado", result.Message);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(12553, result.Data.Folio);
            Assert.AreEqual("Certificación", result.Data.Ambiente);
            Assert.AreEqual("Documento Aceptado con Reparos", result.Data.EstadoSII);
            Assert.AreEqual("Cliente en Marketplace", result.Data.RazonSocialReceptor);
            Assert.AreEqual("66666666-6", result.Data.RutReceptor);
            Assert.AreEqual(990, result.Data.Total);
            Assert.AreEqual(1, result.Data.Detalles.Count);
            Assert.AreEqual("Alfajor", result.Data.Detalles[0].Nombre);
            Assert.AreEqual(990, result.Data.Detalles[0].Total);
        }
        [TestMethod]
        public async Task ObtenerDteAsync_ReturnsBadRequest_WhenApiReturnsFailure()
        {
            // Arrange
            var solicitudDte = new SolicitudDte
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-2",
                    NombreSucursal = "Casa Matriz"
                },
                DteReferenciadoExterno = new DteReferenciadoExterno
                {
                    Folio = 12553,
                    CodigoTipoDte = 39,
                    Ambiente = 0
                }
            };

            var fakeErrorResponse = new Response<Dte>
            {
                Status = 400,
                Message = null,
                Data = null,
                Errors = new[] { "Rut de emisor 76269769-2 no valido" }
            };

            var jsonResponse = JsonConvert.SerializeObject(fakeErrorResponse);

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

            // Act
            var result = await _facturacionService.ObtenerDteAsync(solicitudDte);

            // Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<Dte>>(result.Message);
            Assert.AreEqual(400, response.Status);
            Assert.IsNull(response.Message);
            Assert.IsNull(response.Data);
            Assert.IsNotNull(response.Errors);
            Assert.AreEqual(1, response.Errors.Length);
            Assert.AreEqual("Rut de emisor 76269769-2 no valido", response.Errors[0]);
        }
        [TestMethod]
        public async Task FacturacionIndividualV2DTEAsync_ReturnsOkResult_WhenInvoiceIsGeneratedSuccessfully()
        {
            // Arrange
            var sucursal = "Casa_Matriz";
            var requestDTE = new RequestDTE
            {
                Documento = new Documento
                {
                    Encabezado = new Encabezado
                    {
                        IdDoc = new IdentificacionDTE
                        {
                            TipoDTE = (DTEType)33,
                            FchEmis = DateTime.Now,
                            FmaPago = (FormaPago.FormaPagoEnum)1,
                            FchVenc = DateTime.Now.AddMonths(6)
                        },
                        Emisor = new Emisor
                        {
                            RUTEmisor = "76269769-6",
                            RznSoc = "SERVICIOS INFORMATICOS CHILESYSTEMS EIRL",
                            GiroEmis = "Desarrollo de software",
                            Telefono = new List<string> { "912345678" },
                            CorreoEmisor = "mvega@chilesystems.com",
                            Acteco = new List<int> { 620200 },
                            DirOrigen = "Calle 7 numero 3",
                            CmnaOrigen = "Santiago",
                            CiudadOrigen = "Santiago"
                        },
                        Receptor = new Receptor
                        {
                            RUTRecep = "17096073-4",
                            RznSocRecep = "Hotel Iquique",
                            GiroRecep = "test",
                            CorreoRecep = "mvega@chilesystems.com",
                            DirRecep = "calle 12",
                            CmnaRecep = "Paine",
                            CiudadRecep = "Santiago"
                        },
                        Totales = new Totales
                        {
                            MntNeto = 832,
                            TasaIVA = 19,
                            IVA = 158,
                            MntTotal = 990
                        }
                    },
                    Detalle = new List<Detalle>
                    {
                        new Detalle
                        {
                            NroLinDet = 1,
                            NmbItem = "Alfajor",
                            CdgItem = new List<CodigoItem>
                            {
                                new CodigoItem
                                {
                                    TpoCodigo = "ALFA",
                                    VlrCodigo = "123"
                                }
                            },
                            QtyItem = 1,
                            UnmdItem = "un",
                            PrcItem = 831.932773,
                            MontoItem = 832
                        }
                    }
                },
                Observaciones = "NOTA AL PIE DE PAGINA",
                TipoPago = "30 dias"
            };

            var response = new Response<InvoiceData>
            {
                Status = 200,
                Message = "Con fecha 13-11-2024 17:53:05, se emitió el DTE tipo Factura Electrónica Exenta número 772 desde la sucursal Casa Matriz del emisor SERVICIOS INFORMATICOS CHILESYSTEMS EIRL",
                Data = new InvoiceData
                {
                    TipoDTE = 34,
                    RUTEmisor = "76269769-6",
                    RUTReceptor = "17096073-4",
                    Folio = 772,
                    FechaEmision = "17-08-2024",
                    Total = 990
                },
                Errors = null
            };

            var jsonResponse = JsonConvert.SerializeObject(response);

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

            // Act
            var result = await _facturacionService.FacturacionIndividualV2DTEAsync(sucursal, requestDTE);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.Status);
            Assert.AreEqual(response.Message, result.Message);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(34, result.Data.TipoDTE);
            Assert.AreEqual("76269769-6", result.Data.RUTEmisor);
            Assert.AreEqual("17096073-4", result.Data.RUTReceptor);
            Assert.AreEqual(772, result.Data.Folio);
            Assert.AreEqual("17-08-2024", result.Data.FechaEmision);
            Assert.AreEqual(990, result.Data.Total);
        }
        [TestMethod]
        public async Task FacturacionIndividualV2DTEAsync_ReturnsBadRequest_WhenApiReturnsFailure()
        {
            // Arrange
            var sucursal = "Casa_Matriz";
            var requestDTE = new RequestDTE
            {
                Documento = new Documento
                {
                    Encabezado = new Encabezado
                    {
                        IdDoc = new IdentificacionDTE
                        {
                            //TipoDTE = (DTEType)33, sin TipoDTE
                            FchEmis = DateTime.Now,
                            FmaPago = (FormaPago.FormaPagoEnum)1,
                            FchVenc = DateTime.Now.AddMonths(6)
                        },
                        Emisor = new Emisor
                        {
                            RUTEmisor = "76269769-6",
                            RznSoc = "SERVICIOS INFORMATICOS CHILESYSTEMS EIRL",
                            GiroEmis = "Desarrollo de software",
                            Telefono = new List<string> { "912345678" },
                            CorreoEmisor = "mvega@chilesystems.com",
                            Acteco = new List<int> { 620200 },
                            DirOrigen = "Calle 7 numero 3",
                            CmnaOrigen = "Santiago",
                            CiudadOrigen = "Santiago"
                        },
                        Receptor = new Receptor
                        {
                            RUTRecep = "17096073-4",
                            RznSocRecep = "Hotel Iquique",
                            GiroRecep = "test",
                            CorreoRecep = "mvega@chilesystems.com",
                            DirRecep = "calle 12",
                            CmnaRecep = "Paine",
                            CiudadRecep = "Santiago"
                        },
                        Totales = new Totales
                        {
                            MntNeto = 832,
                            TasaIVA = 19,
                            IVA = 158,
                            MntTotal = 990
                        }
                    },
                    Detalle = new List<Detalle>
                    {
                        new Detalle
                        {
                            NroLinDet = 1,
                            NmbItem = "Alfajor",
                            CdgItem = new List<CodigoItem>
                            {
                                new CodigoItem
                                {
                                    TpoCodigo = "ALFA",
                                    VlrCodigo = "123"
                                }
                            },
                            QtyItem = 1,
                            UnmdItem = "un",
                            PrcItem = 831.932773,
                            MontoItem = 832
                        }
                    }
                },
                Observaciones = "NOTA AL PIE DE PAGINA",
                TipoPago = "30 dias"
            };

            var fakeErrorResponse = new Response<bool>
            {
                Status = 400,
                Message = "Error al facturar desde api",
                Data = false,
                Errors = new[] { "Tipo dte vacio" }
            };

            var jsonResponse = JsonConvert.SerializeObject(fakeErrorResponse);

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

            // Act
            var result = await _facturacionService.FacturacionIndividualV2DTEAsync(sucursal, requestDTE);

            // Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<bool>>(result.Message);
            Assert.AreEqual(400, response.Status);
            Assert.AreEqual("Error al facturar desde api", response.Message);
            Assert.IsFalse(response.Data);
            Assert.IsNotNull(response.Errors);
            Assert.AreEqual(1, response.Errors.Length);
            CollectionAssert.Contains(response.Errors, "Tipo dte vacio");
        }



    }
}