using Newtonsoft.Json;
using SDKSimpleFactura;
using SDKSimpleFactura.Enum;
using SDKSimpleFactura.Models.BoletasHonorarios;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.Folios;
using SDKSimpleFactura.Models.Request;
using static SDKSimpleFactura.Enum.FormaPago;
using static SDKSimpleFactura.Enum.TipoDTE;

namespace AplicacionPruebas
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Datos de autenticación
            string username = "demo@chilesystems.com";
            string password = "Rv8Il4eV";

            // Crear instancias del cliente API
            var clienteApi = new SimpleFacturaClient(username, password);
            var Facturacion = clienteApi.Facturacion;
            var Productos = clienteApi.Productos;
            var Proveedores = clienteApi.Proveedores;
            var Clientes = clienteApi.Clientes;
            var Sucursal = clienteApi.Sucursal;
            var Folio = clienteApi.Folio;
            var Configuracion = clienteApi.Configuracion;
            var BoletasHonorarios = clienteApi.BoletasHonorariosService;
            //ObtenerPDF 
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
            try
            {
                var pdfResponse = await Facturacion.ObtenerPdfDteAsync(solicitudPDF);

                var rutaArchivo = @"C:\Users\luisp\source\repos\SDKSimpleFactura\AplicacionPruebas\Archivos\dte.pdf";
                System.IO.File.WriteAllBytes(rutaArchivo, pdfResponse.Data);

                Console.WriteLine($"El PDF se ha descargado correctamente en: {rutaArchivo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //ObtenerTimbreDteAsync
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
            try
            {
                var timbrestring = await Facturacion.ObtenerTimbreDteAsync(solicitudPDF);
                var timbreBytes = Convert.FromBase64String(timbrestring.Data);
                var rutaArchivo = @"C:\Users\luisp\source\repos\SDKSimpleFactura\AplicacionPruebas\Archivos\timbre.png";
                System.IO.File.WriteAllBytes(rutaArchivo, timbreBytes);

                Console.WriteLine($"El Timbre se ha descargado correctamente en: {rutaArchivo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //prueba dte
            var solicitud = new SolicitudDte
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
            try
            {
                var respuesta = await Facturacion.ObtenerDteAsync(solicitud);

                if (respuesta.Status == 200)
                {
                    Console.WriteLine("entro al status 200");

                    Console.WriteLine($"DTE encontrado: {respuesta.Data.TipoDte}, Folio: {respuesta.Data.Folio}");
                    // Muestra más información según necesites
                }
                else
                {
                    Console.WriteLine($"Error: {respuesta.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //xml
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
            try
            {
                var xmlResponse = await Facturacion.ObtenerXmlDteAsync(solicitudXml);

                var rutaArchivo = @"C:\Users\luisp\source\repos\SDKSimpleFactura\AplicacionPruebas\Archivos\xmldte.xml";
                System.IO.File.WriteAllBytes(rutaArchivo, xmlResponse.Data);

                Console.WriteLine($"El Xml se ha descargado correctamente en: {rutaArchivo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //sobrexml
            var solicitudSobreXML = new SolicitudDte
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
            TipoSobreEnvio tipoSobre = 0;
            try
            {
                var pdfResponse = await Facturacion.ObtenerSobreXmlDteAsync(solicitudSobreXML, tipoSobre);

                var rutaArchivo = @"C:\Users\luisp\source\repos\SDKSimpleFactura\AplicacionPruebas\Archivos\sobrexmldte.xml";
                System.IO.File.WriteAllBytes(rutaArchivo, pdfResponse.Data);

                Console.WriteLine($"El Xml se ha descargado correctamente en: {rutaArchivo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //InvoiceV2
            var documento = new RequestDTE
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
            string sucursal = "Casa_Matriz";
            try
            {
                var result = await Facturacion.FacturacionIndividualV2DTEAsync(sucursal, documento);
                if (result.Status == 200)
                {
                    Console.WriteLine("entro al status 200");
                    Console.WriteLine(result.Message);
                    Console.WriteLine($"DTE encontrado: {result.Data.TipoDTE}, Folio: {result.Data.Folio}");
                }
                else
                {
                    Console.WriteLine($"Error: {result.Status}");
                    Console.WriteLine($"Error: {result.Message}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //InvoiceV2-Boletas
            var documentoBoleta = new RequestDTE
            {
                Documento = new Documento
                {
                    Encabezado = new Encabezado
                    {
                        IdDoc = new IdentificacionDTE
                        {
                            TipoDTE = (DTEType)39,
                            FchEmis = DateTime.Parse("2024-09-03"),
                            FchVenc = DateTime.Parse("2024-09-03"),
                            IndServicio = (IndicadorServicio.IndicadorServicioEnum)3
                        },
                        Emisor = new Emisor
                        {
                            RUTEmisor = "76269769-6",
                            RznSocEmisor = "Chilesystems",
                            GiroEmisor = "Desarrollo de software",
                            DirOrigen = "Calle 7 numero 3",
                            CmnaOrigen = "Santiago"
                        },
                        Receptor = new Receptor
                        {
                            RUTRecep = "17096073-4",
                            RznSocRecep = "Proveedor Test",
                            DirRecep = "calle 12",
                            CmnaRecep = "Paine",
                            CiudadRecep = "Santiago",
                            CorreoRecep = "mercocha13@gmail.com"
                        },
                        Totales = new Totales
                        {
                            MntNeto = 8320,
                            IVA = 1580,
                            MntTotal = 9900
                        }
                    },
                    Detalle = new List<Detalle>
                    {
                        new Detalle
                        {
                            NroLinDet = 1,
                            DscItem = "Desc1",
                            NmbItem = "Producto Test",
                            QtyItem = 1,
                            UnmdItem = "un",
                            PrcItem = 100,
                            MontoItem = 100
                        },
                        new Detalle
                        {
                            NroLinDet = 2,
                            CdgItem = new List<CodigoItem>
                            {
                                new CodigoItem
                                {
                                    TpoCodigo = "ALFA",
                                    VlrCodigo = "123"
                                }
                            },
                            DscItem = "Desc2",
                            NmbItem = "Producto Test",
                            QtyItem = 1,
                            UnmdItem = "un",
                            PrcItem = 100,
                            MontoItem = 100
                        }
                    }
                },
                Observaciones = "NOTA AL PIE DE PAGINA",
                Cajero = "CAJERO",
                TipoPago = "CONTADO"
            };
            try
            {
                var resultBoleta = await Facturacion.FacturacionIndividualV2DTEAsync(sucursal, documentoBoleta);
                if (resultBoleta.Status == 200)
                {
                    Console.WriteLine("entro al status 200");
                    Console.WriteLine(resultBoleta.Message);
                    Console.WriteLine($"DTE encontrado: {resultBoleta.Data.TipoDTE}, Folio: {resultBoleta.Data.Folio}");
                }
                else
                {
                    Console.WriteLine($"Error: {resultBoleta.Message}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //InvoiceExportacion
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
            try
            {
                var resultBoleta = await Facturacion.FacturacionIndividualV2ExportacionAsync(sucursalExportacion, exportacion);
                if (resultBoleta.Status == 200)
                {
                    Console.WriteLine("entro al status 200");
                    Console.WriteLine(resultBoleta.Message);
                    Console.WriteLine($"DTE encontrado: {resultBoleta.Data.TipoDTE}, Folio: {resultBoleta.Data.Folio}");
                }
                else
                {
                    Console.WriteLine($"Error: {resultBoleta.Message}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //InvoiceMassive
            var credenciales = new Credenciales
            {
                RutEmisor = "76269769-6",
                NombreSucursal = "Casa Matriz",
            };
            string pathCsv = @"C:\Users\luisp\source\repos\SDKSimpleFactura\AplicacionPruebas\Archivos\ejemplo_carga_masiva_nacional (2).csv";
            try
            {
                var resultMassive = await Facturacion.FacturacionMasivaAsync(credenciales, pathCsv);
                if (resultMassive.Status == 200)
                {
                    Console.WriteLine("entro al status 200");
                    Console.WriteLine(resultMassive.Message);
                    Console.WriteLine($"Data: {resultMassive.Data}");
                }
                else
                {
                    Console.WriteLine(resultMassive.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //EmisionNC-NDV2
            var documentoNC = new RequestDTE
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
            ReasonTypeEnum motivo = (ReasonTypeEnum)6;
            try
            {
                var resultNC = await Facturacion.EmisionNC_NDV2Async(sucursal, motivo, documentoNC);
                if (resultNC.Status == 200)
                {
                    Console.WriteLine("entro al status 200");
                    Console.WriteLine(resultNC.Message);
                    Console.WriteLine($"Data: {resultNC.Data.TipoDTE}, folio: {resultNC.Data.Folio}");
                }
                else
                {
                    Console.WriteLine($"Error: {resultNC.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //ListadoDte
            var listadoRequest = new ListaDteRequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    RutContribuyente = "10422710-4",
                    NombreSucursal = "Casa Matriz"
                },
                Ambiente = 0,
                Folio = 0,
                CodigoTipoDte = 0,
                Desde = DateTime.Parse("2024-08-01"),
                Hasta = DateTime.Parse("2024-08-17")
            };
            try
            {
                var listado = await Facturacion.ListadoDtesEmitidosAsync(listadoRequest);
                if (listado.Status == 200)
                {
                    Console.WriteLine("entro al status 200");
                    Console.WriteLine(listado.Message);
                    Console.WriteLine($"Data: {listado.Data.First().TipoDte}");
                }
                else
                {
                    Console.WriteLine($"Error: {listado.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //EnvioMail
            var envioMailRequest = new EnvioMailRequest
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
            try
            {
                var mailresponse = await Facturacion.EnvioMailAsync(envioMailRequest);
                if (mailresponse.Status == 200)
                {
                    Console.WriteLine("entro al status 200");
                    Console.WriteLine(mailresponse.Message);
                    Console.WriteLine($"Data: {mailresponse.Data}");
                }
                else
                {
                    Console.WriteLine($"Error: {mailresponse.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //Consolidado de ventas
            var listadoRequestConsolidado = new ListaDteRequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6"
                },
                Ambiente = 0,
                Desde = DateTime.Parse("2023-10-25"),
                Hasta = DateTime.Parse("2023-10-30")
            };
            try
            {
                var listado = await Facturacion.ConsolidadoVentasAsync(listadoRequestConsolidado);
                if (listado.Status == 200)
                {
                    Console.WriteLine("entro al status 200");
                    Console.WriteLine(listado.Message);
                    Console.WriteLine($"Data: {listado.Data.First().TiposDTE}");
                }
                else
                {
                    Console.WriteLine($"Error: {listado.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //Conciliar Emitidos
            var credencialesConsolidado = new Credenciales
            {
                RutEmisor = "76269769-6"
            };
            try
            {
                var listado = await Facturacion.ConsolidadoEmitidosAsync(credencialesConsolidado, 5, 2024);
                if (listado.Status == 200)
                {
                    Console.WriteLine("entro al status 200");
                    Console.WriteLine(listado.Message);
                    Console.WriteLine($"Data: {listado.Data}");
                }
                else
                {
                    Console.WriteLine($"Error: {listado.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //AddProducts
            var datoExternoRequest = new DatoExternoRequest
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
                            Nombre = "Goma 800",
                            CodigoBarra = "goma800",
                            UnidadMedida = "un",
                            Precio = 50,
                            Exento = false,
                            TieneImpuestos = false,
                            Impuestos = new List<int> { 0 }
                        },
                        new NuevoProductoExternoRequest
                        {
                            Nombre = "Goma 800",
                            CodigoBarra = "goma801",
                            UnidadMedida = "un",
                            Precio = 50,
                            Exento = false,
                            TieneImpuestos = true,
                            Impuestos = new List<int> { 271, 23 }
                        }
                    }
            };
            try
            {
                var listado = await Productos.AgregarProductosAsync(datoExternoRequest);
                if (listado.Status == 200)
                {
                    Console.WriteLine("entro al status 200");
                    Console.WriteLine(listado.Message);
                    Console.WriteLine($"Data: {listado.Data.First().Nombre}");
                }
                else
                {
                    Console.WriteLine($"Error: {listado.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //ListProducts
            var credencialesProductos = new Credenciales
            {
                RutEmisor = "76269769-6",
                NombreSucursal = "Casa Matriz"
            };
            try
            {
                var listado = await Productos.ListarProductosAsync(credencialesProductos);
                if (listado.Status == 200)
                {
                    Console.WriteLine("entro al status 200");
                    Console.WriteLine(listado.Message);
                    Console.WriteLine($"Data: {listado.Data.First().Nombre}");
                }
                else
                {
                    Console.WriteLine($"Error: {listado.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //AcuseReciboAsync
            var acuseRequest = new AcuseReciboExternoRequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    RutContribuyente = "76372100-0",
                }
            };
            //sin probar
            //ListadoDtesRecibidosAsync
            var solicitudLista = new ListaDteRequest
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
            try
            {
                var listado = await Proveedores.ListadoDtesRecibidosAsync(solicitudLista);
                if (listado.Status == 200)
                {
                    Console.WriteLine("entro al status 200");
                    Console.WriteLine(listado.Message);
                    Console.WriteLine($"Data: {listado.Data.First().EstadoSII}");
                }
                else
                {
                    Console.WriteLine($"Error: {listado.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //ObtenerXmlAsync
            var solicitudXnlProveedores = new ListaDteRequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    RutContribuyente = "96689310-9"
                },
                Ambiente= (Ambiente.AmbienteEnum)1,
                Folio = 7366834,
                CodigoTipoDte = (DTEType)61
            };
            try
            {
                var listado = await Proveedores.ObtenerXmlAsync(solicitudXnlProveedores);
                if (listado.Status == 200)
                {
                    Console.WriteLine("entro al status 200");
                    Console.WriteLine(listado.Message);
                    Console.WriteLine($"Data: {listado.Data}");
                }
                else
                {
                    Console.WriteLine($"Error: {listado.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //ObtenerPDFAsync
            var solicitudObtenerPDF = new ListaDteRequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    RutContribuyente = "76269769-6"
                },
                Ambiente = (Ambiente.AmbienteEnum)0,
                Folio = 2232,
                CodigoTipoDte = (DTEType)33
            };
            try
            {
                var pdfResponse = await Proveedores.ObtenerPDFAsync(solicitudObtenerPDF);
                var rutaArchivo = @"C:\Users\luisp\source\repos\SDKSimpleFactura\AplicacionPruebas\Archivos\dteRecibido.pdf";
                System.IO.File.WriteAllBytes(rutaArchivo, pdfResponse.Data);

                Console.WriteLine($"El PDF se ha descargado correctamente en: {rutaArchivo}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //ConciliarRecibidosAsync
            var credencialesProveedores = new Credenciales
            {
                RutEmisor = "76269769-6"
            };
            var mes = 5;
            var anio = 2024;
            try
            {
                var response = await Proveedores.ConciliarRecibidosAsync(credencialesProveedores, mes, anio);
                if (response.Status == 200)
                {
                    Console.WriteLine("entro status 200");
                    Console.WriteLine(response.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //AddClients
            var datoExternoRequestClientes = new DatoExternoRequest
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
                    },
                    new NuevoReceptorExternoRequest
                    {
                        Rut = "56516677-8",
                        RazonSocial = "Cliente Test 2",
                        Giro = "Giro 2",
                        DirPart = "direccion 2",
                        DirFact = "direccion 2",
                        CorreoPar = "correo 2",
                        CorreoFact = "correo 2",
                        Ciudad = "Ciudad 2",
                        Comuna = "Comuna 2"
                    },
                    new NuevoReceptorExternoRequest
                    {
                        Rut = "68959276-7",
                        RazonSocial = "Cliente Test 3",
                        Giro = "Giro 3",
                        DirPart = "direccion 3",
                        DirFact = "direccion 3",
                        CorreoPar = "correo 3",
                        CorreoFact = "correo 3",
                        Ciudad = "Ciudad 3",
                        Comuna = "Comuna 3"
                    }
                },
            };
            try
            {
                var response = await Clientes.AgregarClientesAsync(datoExternoRequestClientes);
                if (response.Status == 200)
                {
                    Console.WriteLine("entro status 200");
                    Console.WriteLine(response.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //listclients
            var solicitudClientes = new Credenciales
            {
                RutEmisor = "76269769-6"
            };
            try
            {
                var response = await Clientes.ListarClientesAsync(solicitudClientes);
                if (response.Status == 200)
                {
                    Console.WriteLine("entro status 200");
                    Console.WriteLine(response.Message);
                    Console.WriteLine(response.Data.First().RazonSocial);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //listar sucursal
            var credencialSucursal = new Credenciales
            {
                RutEmisor = "76269769-6"
            };
            try
            {
                var response = await Sucursal.ListadoSucursalesAsync(credencialSucursal);
                if (response.Status == 200)
                {
                    Console.WriteLine("entro status 200");
                    Console.WriteLine(response.Message);
                    Console.WriteLine(response.Data.First().Direccion);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //consulta folios disnponibles
            var solicitudCFD = new SolicitudFoliosRequest
            {
                RutEmpresa = "76269769-6",
                 TipoDTE = 33,
                 Ambiente = 0
            };
            try
            {
                var response = await Folio.ConsultaFoliosDisponiblesAsync(solicitudCFD);
                if (response.Status == 200)
                {
                    Console.WriteLine("entro status 200");
                    Console.WriteLine(response.Message);
                    Console.WriteLine(response.Data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //Solicitar folios
            var solicitudSF = new FolioRequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    NombreSucursal = "Casa Matriz"
                },
                Cantidad = 20,
                CodigoTipoDte = (DTEType)33
            };
            try
            {
                var response = await Folio.SolicitarFoliosAsync(solicitudSF);
                if (response.Status == 200)
                {
                    Console.WriteLine("entro status 200");
                    Console.WriteLine(response.Message);
                    Console.WriteLine(response.Data?.TipoDte);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //consultar folios
            var solicitudCF = new FolioRequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    NombreSucursal = "Casa Matriz"
                },
                CodigoTipoDte = null,
                Ambiente = 0
            };
            try
            {
                var response = await Folio.ConsultarFoliosAsync(solicitudCF);
                if (response.Status == 200)
                {
                    Console.WriteLine("entro status 200");
                    Console.WriteLine(response.Message);
                    Console.WriteLine(response.Data.First().CodigoSii);
                    Console.WriteLine(response.Data.First().FechaIngreso);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //folios sin uso
            var solicitudFSU = new SolicitudFoliosRequest
            {
                RutEmpresa = "76269769-6",
                TipoDTE = 33,
                Ambiente = 0
            };
            try
            {
                var response = await Folio.FoliosSinUsoAsync(solicitudFSU);
                if (response.Status == 200)
                {
                    Console.WriteLine("entro status 200");
                    Console.WriteLine(response.Message);
                    Console.WriteLine(response.Data.First().Desde);
                    Console.WriteLine(response.Data.First().Hasta);
                    Console.WriteLine(response.Data.First().Cantidad);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //datoe mpresa
            var solicitudDE = new Credenciales
            {
                RutEmisor = "76269769-6"
            };
            try
            {
                var response = await Configuracion.DatosEmpresaAsync(solicitudDE);
                if (response.Status == 200)
                {
                    Console.WriteLine("entro status 200");
                    Console.WriteLine(response.Message);
                    Console.WriteLine(response.Data.Rut);
                    Console.WriteLine(response.Data.RazonSocial);
                    Console.WriteLine(response.Data.Giro);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //ObtenerPDFBHEEMITIDAS
            var solicitudBHEPDF = new BHERequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6"
                },
                Folio = 15
            };
            try
            {
                var pdfResponse = await BoletasHonorarios.ObtenerPDFBHEEmitidaAsync(solicitudBHEPDF);

                var rutaArchivo = @"C:\Users\luisp\source\repos\SDKSimpleFactura\AplicacionPruebas\Archivos\bhe.pdf";
                System.IO.File.WriteAllBytes(rutaArchivo, pdfResponse.Data);

                Console.WriteLine($"El PDF se ha descargado correctamente en: {rutaArchivo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //ListadoBHEEmitidos
            var solicitudLBHE = new ListaBHERequest
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
            try
            {
                var response = await BoletasHonorarios.ListadoBHEEmitidasAsync(solicitudLBHE);
                if (response.Status == 200)
                {
                    Console.WriteLine("entro status 200");
                    Console.WriteLine(response.Message);
                    Console.WriteLine(response.Data.First().Emisor.RazonSocial);
                    Console.WriteLine(response.Data.First().FechaEmision);
                    Console.WriteLine(response.Data.First().Estado);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //ObtenerpDFBHERecibidas
            var solicitudBHERPDF = new BHERequest
            {
                Credenciales = new Credenciales
                {
                    RutEmisor = "76269769-6",
                    RutContribuyente = "26429782-6"
                },
                Folio = 2
            };
            try
            {
                var pdfResponse = await BoletasHonorarios.ObtenerPDFBHERecibidosAsync(solicitudBHERPDF);

                var rutaArchivo = @"C:\Users\luisp\source\repos\SDKSimpleFactura\AplicacionPruebas\Archivos\bheCARLOS.pdf";
                System.IO.File.WriteAllBytes(rutaArchivo, pdfResponse.Data);

                Console.WriteLine($"El PDF se ha descargado correctamente en: {rutaArchivo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            //ListadoBHERecibidas
            var solicitudLBHER = new ListaBHERequest
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
            try
            {
                var response = await BoletasHonorarios.ListadoBHERecibidosAsync(solicitudLBHER);
                if (response.Status == 200)
                {
                    Console.WriteLine("entro status 200");
                    Console.WriteLine(response.Message);
                    Console.WriteLine(response.Data.First().Emisor.RazonSocial);
                    Console.WriteLine(response.Data.First().FechaEmision);
                    Console.WriteLine(response.Data.First().Estado);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
            Console.ReadLine();
        }
    }
}
