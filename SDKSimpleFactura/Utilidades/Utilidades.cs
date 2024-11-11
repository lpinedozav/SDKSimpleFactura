using SDKSimpleFactura.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SDKSimpleFactura.Utilidades
{
    public static class Utilidades
    {

        public static string ObtenerNombreTipoDTE(TipoDTE.DTEType tipoDTE)
        {
            string tipo = "NOT SET";
            switch (tipoDTE)
            {
                case TipoDTE.DTEType.FacturaCompraElectronica:
                    tipo = "FACTURA DE COMPRA ELECTRONICA";
                    break;
                case TipoDTE.DTEType.FacturaElectronica:
                    tipo = "FACTURA ELECTRONICA";
                    break;
                case TipoDTE.DTEType.FacturaElectronicaExenta:
                    tipo = "FACTURA ELECTRONICA EXENTA";
                    break;
                case TipoDTE.DTEType.GuiaDespachoElectronica:
                    tipo = "GUIA DE DESPACHO ELECTRONICA";
                    break;
                case TipoDTE.DTEType.NotaCreditoElectronica:
                    tipo = "NOTA DE CREDITO ELECTRONICA";
                    break;
                case TipoDTE.DTEType.NotaDebitoElectronica:
                    tipo = "NOTA DE DEBITO ELECTRONICA";
                    break;
                case TipoDTE.DTEType.BoletaElectronica:
                    tipo = "BOLETA ELECTRONICA";
                    break;
                case TipoDTE.DTEType.BoletaElectronicaExenta:
                    tipo = "BOLETA ELECTRONICA EXENTA";
                    break;
                case TipoDTE.DTEType.LiquidacionFacturaElectronica:
                    tipo = "LIQUIDACIÓN FACTURA ELECTRONICA";
                    break;
                case TipoDTE.DTEType.FacturaExportacionElectronica:
                    tipo = "FACTURA DE EXPORTACIÓN ELECTRONICA";
                    break;
                case TipoDTE.DTEType.NotaCreditoExportacionElectronica:
                    tipo = "NOTA DE CRÉDITO DE EXPORTACIÓN ELECTRONICA";
                    break;
                case TipoDTE.DTEType.NotaDebitoExportacionElectronica:
                    tipo = "NOTA DE DÉBITO DE EXPORTACIÓN ELECTRONICA";
                    break;
            }
            return tipo;
        }

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

        public static string ObtenerNombreFormaPago(FormaPago.FormaPagoEnum formaPago)
        {
            string tipo = "";
            switch (formaPago)
            {
                case FormaPago.FormaPagoEnum.NotSet:
                    tipo = "No Aplica";
                    break;
                case FormaPago.FormaPagoEnum.Contado:
                    tipo = "Contado";
                    break;
                case FormaPago.FormaPagoEnum.Credito:
                    tipo = "Crédito";
                    break;
                case FormaPago.FormaPagoEnum.SinCosto:
                    tipo = "Sin Costo";
                    break;
            }
            return tipo;
        }

        public static X509Certificate2 CrearCertificadoDesdeByteArray(byte[] bytes, string password)
        {
            X509Certificate2 certificado = new X509Certificate2(bytes, password, X509KeyStorageFlags.MachineKeySet |
                   X509KeyStorageFlags.PersistKeySet |
                   X509KeyStorageFlags.Exportable);
            return certificado;
        }

        public static XmlDocument CrearXmlDocumentDesdeByteArray(byte[] bytes)
        {
            XmlDocument documento = new XmlDocument();
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                documento.Load(ms);
            }
            return documento;
        }

        public static List<string> ObtenerCertificadosMaquinas()
        {
            X509Store store = new X509Store(StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            List<string> retorno = new List<string>();
            foreach (X509Certificate2 c in store.Certificates)
            {
                retorno.Add(c.FriendlyName);
            }
            return retorno;
        }

        public static List<string> ObtenerCertificadosUsuario()
        {
            X509Store store = new X509Store(StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            List<string> retorno = new List<string>();
            foreach (X509Certificate2 c in store.Certificates)
            {
                retorno.Add(c.FriendlyName);
            }
            return retorno;
        }

        public static string ConvertEncode(string text)
        {
            //var str = 
            //        Encoding.GetEncoding("ISO-8859-1")
            //        .GetString(Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding("ISO-8859-1"), Encoding.UTF8.GetBytes(text)));
            //return str; 
            return System.Security.SecurityElement.Escape(text);
        }

        public static string EncodeToISO88581(string text)
        {
            Encoding iso8859 = Encoding.GetEncoding("ISO-8859-1");
            Encoding unicode = Encoding.Unicode;
            byte[] srcTextBytes = iso8859.GetBytes(text);
            byte[] destTextBytes = Encoding.Convert(iso8859, unicode, srcTextBytes);
            char[] destChars = new char[unicode.GetCharCount(destTextBytes, 0, destTextBytes.Length)];
            unicode.GetChars(destTextBytes, 0, destTextBytes.Length, destChars, 0);
            StringBuilder result = new StringBuilder(text.Length + (int)(text.Length * 0.1));
            foreach (char c in destChars)
            {
                int value = Convert.ToInt32(c);
                if (value == 34)
                    result.AppendFormat("&quot;");
                else if (value == 38)
                    result.AppendFormat("&amp;");
                else if (value == 39)
                    result.AppendFormat("&apos;");
                else if (value == 60)
                    result.AppendFormat("&lt;");
                else if (value == 62)
                    result.AppendFormat("&gt;");
                else
                    result.Append(c);
            }
            return result.ToString();
        }
    }
}
