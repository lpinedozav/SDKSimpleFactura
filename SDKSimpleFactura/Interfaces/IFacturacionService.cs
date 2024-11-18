using SDKSimpleFactura.Enum;
using SDKSimpleFactura.Models.Facturacion;
using SDKSimpleFactura.Models.Request;
using SDKSimpleFactura.Models.Response;

namespace SDKSimpleFactura.Interfaces
{
    public interface IFacturacionService
    {
        Task<Response<byte[]>> ObtenerPdfDteAsync(SolicitudDte solicitud);
        Task<Response<string>> ObtenerTimbreDteAsync(SolicitudDte solicitud);
        Task<Response<byte[]>> ObtenerXmlDteAsync(SolicitudDte solicitud);
        Task<Response<Dte>> ObtenerDteAsync(SolicitudDte solicitud);
        Task<Response<byte[]>> ObtenerSobreXmlDteAsync(SolicitudDte solicitud, TipoSobreEnvio tipoSobre);
        Task<Response<InvoiceData>> FacturacionIndividualV2DTEAsync(string sucursal, RequestDTE request);
        Task<Response<InvoiceData>> FacturacionIndividualV2ExportacionAsync(string sucursal, RequestDTE request);
        Task<Response<bool>> FacturacionMasivaAsync(Credenciales credenciales, string pathCsv);
        Task<Response<InvoiceData>> EmisionNC_NDV2Async(string sucursal, ReasonTypeEnum motivo, RequestDTE request);
        Task<Response<List<Dte>>> ListadoDtesEmitidosAsync(ListaDteRequest request);
        Task<Response<bool>> EnvioMailAsync(EnvioMailRequest request);
        Task<Response<List<ReporteDTE>>> ConsolidadoVentasAsync(ListaDteRequest request);
        Task<Response<string>> ConsolidadoEmitidosAsync(Credenciales credenciales, int mes, int anio);
    }
}
