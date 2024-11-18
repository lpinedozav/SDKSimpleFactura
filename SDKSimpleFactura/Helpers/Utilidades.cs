using SDKSimpleFactura.Enum;
namespace SDKSimpleFactura.Helpers
{
    public static class Utilidades
    {

        public static string ObtenerNombreTipoDTE(int tipoDTE)
        {
            TipoDTE.DTEType tipoDteEnum = (TipoDTE.DTEType)tipoDTE;
            string tipo = "NOT SET";
            switch (tipoDteEnum)
            {
                case TipoDTE.DTEType.FacturaCompraElectronica:
                    tipo = "FACTURA DE COMPRA ELECTRÓNICA";
                    break;
                case TipoDTE.DTEType.FacturaElectronica:
                    tipo = "FACTURA ELECTRÓNICA";
                    break;
                case TipoDTE.DTEType.FacturaElectronicaExenta:
                    tipo = "FACTURA ELECTRÓNICA EXENTA";
                    break;
                case TipoDTE.DTEType.GuiaDespachoElectronica:
                    tipo = "GUIA DE DESPACHO ELECTRÓNICA";
                    break;
                case TipoDTE.DTEType.NotaCreditoElectronica:
                    tipo = "NOTA DE CRÉDITO ELECTRÓNICA";
                    break;
                case TipoDTE.DTEType.NotaDebitoElectronica:
                    tipo = "NOTA DE DÉBITO ELECTRÓNICA";
                    break;
                case TipoDTE.DTEType.BoletaElectronica:
                    tipo = "BOLETA ELECTRÓNICA";
                    break;
                case TipoDTE.DTEType.BoletaElectronicaExenta:
                    tipo = "BOLETA ELECTRÓNICA EXENTA";
                    break;
                case TipoDTE.DTEType.FacturaExportacionElectronica:
                    tipo = "FACTURA DE EXPORTACIÓN";
                    break;
                case TipoDTE.DTEType.NotaDebitoExportacionElectronica:
                    tipo = "NOTA DÉBITO DE EXPORTACIÓN";
                    break;
                case TipoDTE.DTEType.NotaCreditoExportacionElectronica:
                    tipo = "NOTA CRÉDITO DE EXPORTACIÓN";
                    break;
                case TipoDTE.DTEType.NotSet:
                    tipo = "DOCUMENTO DE PROVEEDORES";
                    break;
                case TipoDTE.DTEType.LiquidacionFacturaElectronica:
                    tipo = "LIQUIDACIÓN DE FACTURA";
                    break;
            }
            return tipo;
        }
    }
}
