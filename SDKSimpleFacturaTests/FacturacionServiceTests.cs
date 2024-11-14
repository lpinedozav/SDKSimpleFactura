using Newtonsoft.Json;
using SDKSimpleFactura;
using SDKSimpleFactura.Enum;
using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Models;
using SDKSimpleFactura.Models.Facturacion;
using static SDKSimpleFactura.Enum.FormaPago;
using static SDKSimpleFactura.Enum.TipoDTE;

namespace SDKSimpleFacturaTests
{
    [TestClass]
    public class FacturacionServiceTests
    {
        private SimpleFacturaClient? _simpleFacturaClient;
        private IFacturacionService? _facturacionService;

        [TestInitialize]
        public void Setup()
        {
            string username = "demo@chilesystems.com";
            string password = "Rv8Il4eV";
            _simpleFacturaClient = new SimpleFacturaClient(username,password);
            _facturacionService = _simpleFacturaClient.Facturacion;
        }
        [TestMethod]
        public async Task ObtenerPdfDteAsync_RetunsOkResult_WhenPDFIsGeneratedSucessfully()
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
            // Act
            var result = await _facturacionService.ObtenerPdfDteAsync(solicitudPDF);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.Status);
            Assert.IsNotNull(result.Data);
            Assert.IsInstanceOfType(result.Data, typeof(byte[]));
            Assert.IsNull(result.Message);
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task ObtenerPdfDteAsync_ReturnsError_WhenFolioNotFoundInRequest()
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
                    CodigoTipoDte = 33,
                    Ambiente = 0
                }
            };

            // Act
            var result = await _facturacionService.ObtenerPdfDteAsync(solicitudPDF);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.Status);
            Assert.IsNull(result.Data);
            Assert.IsTrue(result.Message.Contains("Error en la peticion"));
            Assert.IsNull(result.Errors);
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

            // Act
            var result = await _facturacionService.ObtenerTimbreDteAsync(solicitudTimbre);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.Status);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(result.Message, "Timbre del DTE tipo FacturaElectronica con folio 4117 de la empresa 76269769-6");
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task ObtenerTimbreDteAsync_ReturnsError_WhenFolioIsInvalid()
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
                    Folio = 999999999,
                    CodigoTipoDte = 33,
                    Ambiente = 0
                }
            };
            // Act
            var result = await _facturacionService.ObtenerTimbreDteAsync(solicitudTimbre);
            // Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<string>>(result.Message);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, 500);
            Assert.AreEqual(response.Data, "Error al obtener xml desde api");
            Assert.IsNull(response.Message);
            CollectionAssert.Contains(response.Errors, "DTE no encontrado");
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
            //Act
            var result = await _facturacionService.ObtenerXmlDteAsync(solicitudXml);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.Status);
            Assert.IsNotNull(result.Data);
            Assert.IsInstanceOfType(result.Data, typeof(byte[]));
            Assert.IsNull(result.Message);
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task ObtenerXmlDteAsync_ResturnsError_WhenApiReturnsFailure()
        {
            //Arrange
            var request = new SolicitudDte
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                },
                DteReferenciadoExterno = new DteReferenciadoExterno
                {
                    CodigoTipoDte = 39,
                    Ambiente = 0
                }
            };           
            //Act
            var result = await _facturacionService.ObtenerXmlDteAsync(request);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.Status);
            Assert.IsNull(result.Data);
            Assert.IsTrue(result.Message.Contains("Error en la peticion"));
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task ObtenerSobreXmlDteAsync_ReturnsOkResult_WhenXmlSobreIsGeneratedSuccessfully()
        {
            // Arrange
            var solicitudXmlSobre = new SolicitudDte
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                },
                DteReferenciadoExterno = new DteReferenciadoExterno
                {
                    Folio = 2393,
                    CodigoTipoDte = 33,
                    Ambiente = 0
                }
            };
            // Act
            var result = await _facturacionService.ObtenerSobreXmlDteAsync(solicitudXmlSobre, TipoSobreEnvio.AlSII);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.Status);
            Assert.IsNotNull(result.Data);
            Assert.IsInstanceOfType(result.Data, typeof(byte[]));
            Assert.IsNull(result.Message);
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task ObtenerSobreXmlDteAsync_ReturnsError_WhenApiReturnsFailure()
        {
            // Arrange
            var request = new SolicitudDte
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                },
                DteReferenciadoExterno = new DteReferenciadoExterno
                {
                    CodigoTipoDte = 33,
                    Ambiente = 0
                }
            };              
            // Act
            var result = await _facturacionService.ObtenerSobreXmlDteAsync(request, TipoSobreEnvio.AlReceptor);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.Status);
            Assert.IsNull(result.Data);
            Assert.IsTrue(result.Message.Contains("Error en la peticion"));
            Assert.IsNull(result.Errors);
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
            var request = new SolicitudDte
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

            // Act
            var result = await _facturacionService.ObtenerDteAsync(request);

            // Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<bool>>(result.Message);
            Assert.AreEqual(400, response.Status);
            Assert.IsNull(response.Message);
            Assert.IsFalse(response.Data);
            Assert.IsNotNull(response.Errors);
            CollectionAssert.Contains(response.Errors, "Rut de emisor 76269769-2 no valido");
        }
        [TestMethod]
        public async Task FacturacionIndividualV2DTEAsync_ReturnsOkResult_WhenInvoiceIsGeneratedSuccessfully()
        {
            // Arrange
            var sucursal = "Casa_Matriz";
            var request = new RequestDTE
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

            // Act
            var result = await _facturacionService.FacturacionIndividualV2DTEAsync(sucursal, request);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.Status);
            Assert.IsInstanceOfType(result.Data,typeof(InvoiceData));
            Assert.AreEqual(result.Data.RUTEmisor, "76269769-6");
            Assert.AreEqual(result.Data.RUTReceptor, "17096073-4");
            Assert.IsNotNull(result.Message);
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task FacturacionIndividualV2DTEAsync_ReturnsBadRequest_WhenTipoDTEIsNotFound()
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
        [TestMethod]
        public async Task FacturacionIndividualV2ExportacionAsync_ReturnsOkResult_WhenInvoiceIsGeneratedSuccessfully()
        {
            //Arrange
            var exportacion = new RequestDTE
            {
                Exportaciones = new Exportaciones
                {
                    Encabezado = new Encabezado
                    {
                        IdDoc = new IdentificacionDTE
                        {
                            TipoDTE = (DTEType)110,
                            FchEmis = DateTime.Parse("2024-08-17"),
                            FmaPago = (FormaPagoEnum)1,
                            FchVenc = DateTime.Parse("2024-08-17")
                        },
                        Emisor = new Emisor
                        {
                            RUTEmisor = "76269769-6",
                            RznSoc = "Chilesystems",
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
                            RUTRecep = "55555555-5",
                            RznSocRecep = "CLIENTE INTERNACIONAL EXP IMP",
                            Extranjero = new Extranjero
                            {
                                NumId = "331-555555",
                                Nacionalidad = (CodigosAduana.Paises)331
                            },
                            GiroRecep = "Giro de Cliente",
                            CorreoRecep = "amamani@chilesystems.com",
                            DirRecep = "Dirección de Cliente",
                            CmnaRecep = "Comuna de Cliente",
                            CiudadRecep = "Ciudad de Cliente"
                        },
                        Transporte = new Transporte
                        {
                            Aduana = new Aduana
                            {
                                CodModVenta = (CodigosAduana.ModalidadVenta)1,
                                CodClauVenta = (CodigosAduana.ClausulaCompraVenta)5,
                                TotClauVenta = 1984.65,
                                CodViaTransp = (CodigosAduana.ViasdeTransporte)4,
                                CodPtoEmbarque = (CodigosAduana.Puertos)901,
                                CodPtoDesemb = (CodigosAduana.Puertos)262,
                                Tara = 1,
                                CodUnidMedTara = (CodigosAduana.UnidadMedida)10,
                                PesoBruto = 10.65,
                                CodUnidPesoBruto = (CodigosAduana.UnidadMedida)6,
                                PesoNeto = 9.56,
                                CodUnidPesoNeto = (CodigosAduana.UnidadMedida)6,
                                TotBultos = 30,
                                TipoBultos = new List<TipoBulto>
                        {
                            new TipoBulto
                            {
                                CodTpoBultos = (CodigosAduana.TipoBultoEnum)75,
                                CantBultos = 30,
                                IdContainer = "1-2",
                                Sello = "1-3",
                                EmisorSello = "CONTENEDOR"
                            }
                        },
                                MntFlete = 965.1,
                                MntSeguro = 10.25,
                                CodPaisRecep = (CodigosAduana.Paises)224,
                                CodPaisDestin = (CodigosAduana.Paises)224
                            }
                        },
                        Totales = new Totales
                        {
                            TpoMoneda = (CodigosAduana.Moneda)13,
                            MntExe = 1000,
                            MntTotal = 1000
                        },
                        OtraMoneda = new OtraMoneda
                        {
                            TpoMoneda = (CodigosAduana.Moneda)200,
                            TpoCambio = 800.36,
                            MntExeOtrMnda = 45454.36,
                            MntTotOtrMnda = 45454.36
                        }
                    },
                    Detalle = new List<DetalleExportacion>
                        {
                            new DetalleExportacion
                            {
                                NroLinDet = 1,
                                CdgItem = new List<CodigoItem>
                                {
                                    new CodigoItem
                                    {
                                        TpoCodigo = "INT1",
                                        VlrCodigo = "39"
                                    }
                                },
                                IndExe = (IndicadorFacturacionExencionEnum)1,
                                NmbItem = "CHATARRA DE ALUMINIO",
                                DscItem = "OPCIONAL",
                                QtyItem = 1,
                                UnmdItem = "U",
                                PrcItem = 1000,
                                MontoItem = 1000
                            }
                        }
                },
                Observaciones = "NOTA AL PIE DE PAGINA"
            };
            string sucursalExportacion = "Casa Matriz";
            // Act
            var result = await _facturacionService.FacturacionIndividualV2ExportacionAsync(sucursalExportacion, exportacion);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.Status);
            Assert.IsInstanceOfType(result.Data, typeof(InvoiceData));
            Assert.AreEqual(result.Data.RUTEmisor, "76269769-6");
            Assert.AreEqual(result.Data.RUTReceptor, "55555555-5");
            Assert.IsNotNull(result.Message);
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task FacturacionIndividualV2ExportacionAsync_ReturnsError_WhenRutEmisorIsNotFound()
        {
            //Arrange
            string sucursalExportacion = "Casa Matriz";
            var exportacion = new RequestDTE
            {
                Exportaciones = new Exportaciones
                {
                    Encabezado = new Encabezado
                    {
                        IdDoc = new IdentificacionDTE
                        {
                            TipoDTE = (DTEType)110,
                            FchEmis = DateTime.Parse("2024-08-17"),
                            FmaPago = (FormaPagoEnum)1,
                            FchVenc = DateTime.Parse("2024-08-17")
                        },
                        Emisor = new Emisor
                        {
                            //RUTEmisor = "76269769-6", sin emisor
                            RznSoc = "Chilesystems",
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
                            RUTRecep = "55555555-5",
                            RznSocRecep = "CLIENTE INTERNACIONAL EXP IMP",
                            Extranjero = new Extranjero
                            {
                                NumId = "331-555555",
                                Nacionalidad = (CodigosAduana.Paises)331
                            },
                            GiroRecep = "Giro de Cliente",
                            CorreoRecep = "amamani@chilesystems.com",
                            DirRecep = "Dirección de Cliente",
                            CmnaRecep = "Comuna de Cliente",
                            CiudadRecep = "Ciudad de Cliente"
                        },
                        Transporte = new Transporte
                        {
                            Aduana = new Aduana
                            {
                                CodModVenta = (CodigosAduana.ModalidadVenta)1,
                                CodClauVenta = (CodigosAduana.ClausulaCompraVenta)5,
                                TotClauVenta = 1984.65,
                                CodViaTransp = (CodigosAduana.ViasdeTransporte)4,
                                CodPtoEmbarque = (CodigosAduana.Puertos)901,
                                CodPtoDesemb = (CodigosAduana.Puertos)262,
                                Tara = 1,
                                CodUnidMedTara = (CodigosAduana.UnidadMedida)10,
                                PesoBruto = 10.65,
                                CodUnidPesoBruto = (CodigosAduana.UnidadMedida)6,
                                PesoNeto = 9.56,
                                CodUnidPesoNeto = (CodigosAduana.UnidadMedida)6,
                                TotBultos = 30,
                                TipoBultos = new List<TipoBulto>
                        {
                            new TipoBulto
                            {
                                CodTpoBultos = (CodigosAduana.TipoBultoEnum)75,
                                CantBultos = 30,
                                IdContainer = "1-2",
                                Sello = "1-3",
                                EmisorSello = "CONTENEDOR"
                            }
                        },
                                MntFlete = 965.1,
                                MntSeguro = 10.25,
                                CodPaisRecep = (CodigosAduana.Paises)224,
                                CodPaisDestin = (CodigosAduana.Paises)224
                            }
                        },
                        Totales = new Totales
                        {
                            TpoMoneda = (CodigosAduana.Moneda)13,
                            MntExe = 1000,
                            MntTotal = 1000
                        },
                        OtraMoneda = new OtraMoneda
                        {
                            TpoMoneda = (CodigosAduana.Moneda)200,
                            TpoCambio = 800.36,
                            MntExeOtrMnda = 45454.36,
                            MntTotOtrMnda = 45454.36
                        }
                    },
                    Detalle = new List<DetalleExportacion>
                        {
                            new DetalleExportacion
                            {
                                NroLinDet = 1,
                                CdgItem = new List<CodigoItem>
                                {
                                    new CodigoItem
                                    {
                                        TpoCodigo = "INT1",
                                        VlrCodigo = "39"
                                    }
                                },
                                IndExe = (IndicadorFacturacionExencionEnum)1,
                                NmbItem = "CHATARRA DE ALUMINIO",
                                DscItem = "OPCIONAL",
                                QtyItem = 1,
                                UnmdItem = "U",
                                PrcItem = 1000,
                                MontoItem = 1000
                            }
                        }
                },
                Observaciones = "NOTA AL PIE DE PAGINA"
            };            
            // Act
            var result = await _facturacionService.FacturacionIndividualV2ExportacionAsync(sucursalExportacion, exportacion);
            //Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<string>>(result.Message);
            Assert.AreEqual(500, response.Status);
            Assert.AreEqual("Error al facturar desde api", response.Message);
            Assert.IsNotNull(response.Data);
            Assert.IsNotNull(response.Errors);
            Assert.AreEqual(1, response.Errors.Length);
            CollectionAssert.Contains(response.Errors, "Rut emisor inválido");
        }
        [TestMethod]
        public async Task FacturacionMasivaAsync_ReturnsOkResult_WhenApiCallIsSuccessful()
        {
            // Arrange
            var credenciales = new Credenciales
            {
                RutEmisor = "76269769-6",
                NombreSucursal = "Casa Matriz"
            };
            var tempFilePath = Path.GetTempFileName();
            var dataCsv = "Id;TipoDte;FmaPago;FechaEmision;Vencimiento;RutRecep;GiroRecep;Contacto;CorreoRecep;DirRecep;CmnaRecep;CiudadRecep;RazonSocialRecep;DirDest;CmnaDest;CiudadDest;ReferenciaTpoDocRef;ReferenciaFolioRef;ReferenciaFchRef;ReferenciaRazonRef;ReferenciaCodigo;CodigoProducto;NombreProducto;DescripcionProducto;CantidadProducto;PrecioProducto;UnidadMedidaProducto;DescuentoProducto;RecargoProducto;IndicadorExento;TotalProducto\r\n1;33;2;06-11-2024;06-12-2024;11111111-1;Reparación de vehículos;98765412;contacto@cliente.cl;Av. 21 de Mayo 547;Providencia;Santiago;Reparadora de vehículos SpA;Av. 21 de Mayo 547;Providencia;Santiago;;;;;;1347864355;REPUESTO DJ11-18;REPUESTO DJ11-18;61;99843;UN;0;0;0;6090423\r\n2;33;2;06-11-2024;06-12-2024;11111111-1;Reparación de vehículos;98765412;contacto@cliente.cl;Av. 21 de Mayo 547;Providencia;Santiago;Reparadora de vehículos SpA;Av. 21 de Mayo 547;Providencia;Santiago;;;;;;1795083977;REPUESTO WB45-469;REPUESTO WB45-469;51;90843;UN;0;0;0;4632993\r\n";
            File.WriteAllText(tempFilePath, dataCsv);
            // Act
            var result = await _facturacionService.FacturacionMasivaAsync(credenciales, tempFilePath);
            File.Delete(tempFilePath);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Data);
            Assert.AreEqual(200, result.Status);
            Assert.IsNotNull(result.Message);
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task FacturacionMasivaAsync_ReturnsInternalServerError_WhenApiReturnsServerError()
        {
            // Arrange
            var credenciales = new Credenciales
            {
                RutEmisor = "76269769-6",
                NombreSucursal = "Casa Matriz"
            };

            var tempFilePath = Path.GetTempFileName();
            File.WriteAllText(tempFilePath, "campo1,campo2,campo3\nvalor1,valor2,valor3");
            // Act
            var result = await _facturacionService.FacturacionMasivaAsync(credenciales, tempFilePath);

            // Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<string>>(result.Message);
            Assert.IsNotNull(response);
            Assert.AreEqual(500, response.Status);
            Assert.IsNull(response.Message);
            Assert.AreEqual("Error al facturar masivamente desde api", response.Data);
            Assert.IsNotNull(response.Errors);
            CollectionAssert.Contains(response.Errors, "Object reference not set to an instance of an object.");
        }
        [TestMethod]
        public async Task EmisionNC_NDV2Async_ReturnsOkResult_WhenApiCallIsSuccessful()
        {
            // Arrange
            var sucursal = "Casa_Matriz";
            var motivo = ReasonTypeEnum.Otros;
            var request = new RequestDTE
            {
                Documento = new Documento
                {
                    Encabezado = new Encabezado
                    {
                        IdDoc = new IdentificacionDTE
                        {
                            TipoDTE = (DTEType)56,
                            FchEmis = DateTime.Parse("2024-08-13"),
                            FmaPago = (FormaPagoEnum)2,
                            FchVenc = DateTime.Parse("2024-09-12")
                        },
                        Emisor = new Emisor
                        {
                            RUTEmisor = "76269769-6",
                            RznSoc = "SERVICIOS INFORMATICOS CHILESYSTEMS EIRL",
                            GiroEmis = "Desarrollo de software",
                            Telefono = new List<string> { "912345678" },
                            CorreoEmisor = "felipe.anzola@erke.cl",
                            Acteco = new List<int> { 620900 },
                            DirOrigen = "Chile",
                            CmnaOrigen = "Chile",
                            CiudadOrigen = "Chile"
                        },
                        Receptor = new Receptor
                        {
                            RUTRecep = "77225200-5",
                            RznSocRecep = "ARRENDADORA DE VEHÍCULOS S.A.",
                            GiroRecep = "451001 - VENTA AL POR MAYOR DE VEHÍCULOS AUTOMOTORES",
                            CorreoRecep = "terceros-77225200@dte.iconstruye.com",
                            DirRecep = "Rondizzoni 2130",
                            CmnaRecep = "SANTIAGO",
                            CiudadRecep = "SANTIAGO"
                        },
                        Totales = new Totales
                        {
                            MntNeto = 6930000.0,
                            TasaIVA = 19,
                            IVA = 1316700,
                            MntTotal = 8246700.0
                        }
                    },
                    Detalle = new List<Detalle>
                    {
                        new Detalle
                        {
                            NroLinDet = 1,
                            NmbItem = "CERRADURA DE SEGURIDAD (2PIEZA).SATURN EVO",
                            CdgItem = new List<CodigoItem>
                            {
                                new CodigoItem
                                {
                                    TpoCodigo = "4",
                                    VlrCodigo = "EVO_2"
                                }
                            },
                            QtyItem = 42.0,
                            UnmdItem = "unid",
                            PrcItem = 319166.0,
                            MontoItem = 6930000
                        }
                    },
                    Referencia = new List<Referencia>
                    {
                        new Referencia
                        {
                            NroLinRef = 1,
                            TpoDocRef = "61",
                            FolioRef = "1268",
                            FchRef = DateTime.Parse("2024-10-17"),
                            CodRef = (TipoReferencia.TipoReferenciaEnum)1,
                            RazonRef = "Anular"
                        }
                    }
                }
            };
            // Act
            var result = await _facturacionService.EmisionNC_NDV2Async(sucursal, motivo, request);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.Status);
            Assert.IsInstanceOfType(result.Data, typeof(InvoiceData));
            Assert.AreEqual(result.Data.RUTEmisor, "76269769-6");
            Assert.AreEqual(result.Data.RUTReceptor, "77225200-5");
            Assert.IsNotNull(result.Message);
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task EmisionNC_NDV2Async_ReturnsBadRequest_WhenTipoDTEIsNotFound()
        {
            // Arrange
            var sucursal = "Casa_Matriz";
            var motivo = ReasonTypeEnum.Otros;
            var request = new RequestDTE
            {
                Documento = new Documento
                {
                    Encabezado = new Encabezado
                    {
                        IdDoc = new IdentificacionDTE
                        {
                            //TipoDTE = (DTEType)56,
                            FchEmis = DateTime.Parse("2024-08-13"),
                            FmaPago = (FormaPagoEnum)2,
                            FchVenc = DateTime.Parse("2024-09-12")
                        },
                        Emisor = new Emisor
                        {
                            RUTEmisor = "76269769-6",
                            RznSoc = "SERVICIOS INFORMATICOS CHILESYSTEMS EIRL",
                            GiroEmis = "Desarrollo de software",
                            Telefono = new List<string> { "912345678" },
                            CorreoEmisor = "felipe.anzola@erke.cl",
                            Acteco = new List<int> { 620900 },
                            DirOrigen = "Chile",
                            CmnaOrigen = "Chile",
                            CiudadOrigen = "Chile"
                        },
                        Receptor = new Receptor
                        {
                            RUTRecep = "77225200-5",
                            RznSocRecep = "ARRENDADORA DE VEHÍCULOS S.A.",
                            GiroRecep = "451001 - VENTA AL POR MAYOR DE VEHÍCULOS AUTOMOTORES",
                            CorreoRecep = "terceros-77225200@dte.iconstruye.com",
                            DirRecep = "Rondizzoni 2130",
                            CmnaRecep = "SANTIAGO",
                            CiudadRecep = "SANTIAGO"
                        },
                        Totales = new Totales
                        {
                            MntNeto = 6930000.0,
                            TasaIVA = 19,
                            IVA = 1316700,
                            MntTotal = 8246700.0
                        }
                    },
                    Detalle = new List<Detalle>
                    {
                        new Detalle
                        {
                            NroLinDet = 1,
                            NmbItem = "CERRADURA DE SEGURIDAD (2PIEZA).SATURN EVO",
                            CdgItem = new List<CodigoItem>
                            {
                                new CodigoItem
                                {
                                    TpoCodigo = "4",
                                    VlrCodigo = "EVO_2"
                                }
                            },
                            QtyItem = 42.0,
                            UnmdItem = "unid",
                            PrcItem = 319166.0,
                            MontoItem = 6930000
                        }
                    },
                    Referencia = new List<Referencia>
                    {
                        new Referencia
                        {
                            NroLinRef = 1,
                            TpoDocRef = "61",
                            FolioRef = "1268",
                            FchRef = DateTime.Parse("2024-10-17"),
                            CodRef = (TipoReferencia.TipoReferenciaEnum)1,
                            RazonRef = "Anular"
                        }
                    }
                }
            };

            // Act
            var result = await _facturacionService.EmisionNC_NDV2Async(sucursal, motivo, request);

            // Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<bool>>(result.Message);
            Assert.AreEqual(400, response.Status);
            Assert.IsNull(response.Message);
            Assert.IsFalse(response.Data);
            Assert.IsNotNull(response.Errors);
            CollectionAssert.Contains(response.Errors, "Tipo dte vacio");
        }
        [TestMethod]
        public async Task ListadoDtesEmitidosAsync_ReturnsOkResult_WhenApiCallIsSuccessful()
        {
            // Arrange
            var request = new ListaDteRequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    NombreSucursal = "Casa__Matriz"
                },
                Desde = DateTime.Now,
                Hasta = DateTime.Now,
            };
            // Act
            var result = await _facturacionService.ListadoDtesEmitidosAsync(request);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.Status);
            Assert.IsNotNull(result.Message);
            Assert.IsTrue(result.Data.Count >= 0);
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task ListadoDtesEmitidosAsync_ReturnsError_WhenApiCallFails()
        {
            // Arrange
            var request = new ListaDteRequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    NombreSucursal = "Casa__Matriz"
                }
            };
            // Act
            var result = await _facturacionService.ListadoDtesEmitidosAsync(request);
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<bool>>(result.Message);
            Assert.AreEqual(400, response.Status);
            Assert.IsNull(response.Message);
            Assert.IsFalse(response.Data);
            Assert.IsNotNull(response.Errors);
            CollectionAssert.Contains(response.Errors, "Si no se envían filtros de fecha, debe tener al menos un folio");

        }
        [TestMethod]
        public async Task EnvioMailAsync_ReturnOkResult_WhenMailIsSentSuccessfully()
        {
            //Arrange
            var request = new EnvioMailRequest
            {
                RutEmpresa = "76269769-6",
                Dte = new EnvioMailRequest.DteClass
                {
                    folio = 2149,
                    tipoDTE = 33
                },
                Mail = new EnvioMailRequest.MailClass
                {
                    to = new List<string> { "contacto@chilesystems.com" },
                    ccos = new List<string> { "correo@gmail.com" },
                    ccs = new List<string> { "correo2@gmail.com" }
                },
                Xml = true,
                Pdf = true,
                Comments = "ESTO ES UN COMENTARIO"
            };
            var fakeResponse = new Response<bool>{
                Status = 200,
                Message = "Email Enviado con Exito",
                Data = true, 
                Errors = null
            };
            var jsonResponse = JsonConvert.SerializeObject(fakeResponse);
            //Act
            var result = await _facturacionService.EnvioMailAsync(request);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, 200);
            Assert.AreEqual(result.Message, "Email Enviado con Exito");
            Assert.IsTrue(result.Data);
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task EnvioMailAsync_ReturnsBadRequest_WhenApiCallFails()
        {
            //Arrange
            var request = new EnvioMailRequest
            {
                //RutEmpresa = "76269769-6",
                Dte = new EnvioMailRequest.DteClass
                {
                    folio = 2149,
                    tipoDTE = 33
                },
                Mail = new EnvioMailRequest.MailClass
                {
                    to = new List<string> { "contacto@chilesystems.com" },
                    ccos = new List<string> { "correo@gmail.com" },
                    ccs = new List<string> { "correo2@gmail.com" }
                },
                Xml = true,
                Pdf = true,
                Comments = "ESTO ES UN COMENTARIO"
            };
            //Act
            var result = await _facturacionService.EnvioMailAsync(request);
            //Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<string>>(result.Message);
            Assert.IsNotNull (response);
            Assert.AreEqual(response.Status,400);
            Assert.AreEqual(response.Message, "Rut de empresa vacio");
            Assert.IsNotNull(response.Data);
            Assert.IsNull(response.Errors);
        }
        [TestMethod]
        public async Task ConsolidadoVentasAsync_ReturnsOkResult_WhenApiCallIsSuccessfully()
        {
            //Arrange
            var request = new ListaDteRequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6"
                },
                Ambiente = 0,
                Desde = DateTime.Parse("2023-10-25"),
                Hasta = DateTime.Parse("2023-10-30")
            };
            //Act
            var result = await _facturacionService.ConsolidadoVentasAsync(request);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, 200);
            Assert.AreEqual(result.Message, "Exito");
            Assert.IsInstanceOfType(result.Data, typeof(List<ReporteDTE>));
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task ConsolidadoVentasAsync_ReturnError_WhenApiCallFails()
        {
            //Arrange
            var request = new ListaDteRequest
            {
                Credenciales = new Credenciales
                {
                    //RutEmisor = "76269769-6"
                },
                Ambiente = 0,
                Desde = DateTime.Parse("2023-10-25"),
                Hasta = DateTime.Parse("2023-10-30")
            };
            //Act
            var result = await _facturacionService.ConsolidadoVentasAsync(request);
            //Assert
            Assert.IsNotNull(result);
            var response = JsonConvert.DeserializeObject<Response<string>>(result.Message);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status,500);
            Assert.IsNull(response.Message);
            Assert.AreEqual(response.Data, "Error al obtener consolidado de emitidos desde api");
            CollectionAssert.Contains(response.Errors, "Rut de empresa vacio");
        }
        [TestMethod]
        public async Task ConsolidadoEmitidosAsync_ReturnsOkResult_WhenApiCallIsSuccessfully()
        {
            //Arrange
            var credencialesConsolidado = new Credenciales
            {
                RutEmisor = "76269769-6"
            };
            //Act
            var result = await _facturacionService.ConsolidadoEmitidosAsync(credencialesConsolidado,5,2024);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, 200);
            Assert.AreEqual(result.Message, "Datos Obtenidos correctamente");
            Assert.AreEqual(result.Data, "Datos Obtenidos correctamente");
            Assert.IsNull(result.Errors);
        }
        [TestMethod]
        public async Task ConsolidadoEmitidosAsync_ReturnsBadRequest_WhenApiCallQuotaExcceeded()
        {
            //Arrange
            var credencialesConsolidado = new Credenciales
            {
                //RutEmisor = "76269769-6"
            };
            //Act
            var result = await _facturacionService.ConsolidadoEmitidosAsync(credencialesConsolidado, 5, 2024);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, 500);
            Assert.IsTrue(result.Message.Contains("Rut de emisor vacio"));
            Assert.IsNull(result.Data);
            Assert.IsNull(result.Errors);
        }
    }
}