using Newtonsoft.Json;
using SDKSimpleFactura;
using SDKSimpleFactura.Enum;
using SDKSimpleFactura.Helpers;
using SDKSimpleFactura.Models.Facturacion;
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

            // Crear instancia del cliente API
            var clienteApi = new ClientApi(username, password);
            var Facturacion = clienteApi.Facturacion;

            // Crear la solicitud
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
            //prueba dte
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
            try
            {
                var pdfBytes = await Facturacion.ObtenerSobreXmlDteAsync(solicitudSobreXML);

                var rutaArchivo = @"C:\Users\luisp\source\repos\SDKSimpleFactura\AplicacionPruebas\Archivos\sobrexmldte.xml";
                System.IO.File.WriteAllBytes(rutaArchivo, pdfBytes);

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
            try
            {
                var result = await Facturacion.FacturacionIndividualV2DTE(documento);
                if (result.Status == 200)
                {
                    Console.WriteLine("entro al status 200");
                    Console.WriteLine(result.Message);
                    Console.WriteLine($"DTE encontrado: {result.Data.TipoDTE}, Folio: {result.Data.Folio}");
                }
                else
                {
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
                var resultBoleta = await Facturacion.FacturacionIndividualV2DTE(documentoBoleta);
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
            try
            {
                var resultBoleta = await Facturacion.FacturacionIndividualV2Exportacion(exportacion);
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
            
            Console.ReadLine();
        }
    }
}
