using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class Totales
    {
        public Enum.CodigosAduana.Moneda TpoMoneda { get; set; }

        /// <summary>
        /// Monto neto del DTE.
        /// Suma de valores total de ítems afectos - descuentos globales + recargos globales (Asignados a ítems afectos).
        /// Si está encendido el Indicador de Montos Brutos (=1) entonces el resultado anterior se debe dividir por (1 + tasa de IVA).
        /// </summary>
        public double MntNeto { get; set; }

        /// <summary>
        /// Monto exento del DTE.
        /// Suma de valores total de ítems no afectos o exentos - descuentos globales + recargos globales (Asignados a ítems exentos o no afectos).
        /// </summary>
        public double MntExe { get; set; }

        /// <summary>
        /// Monto base faenamiento de carne.
        /// Monto informado.
        /// </summary>
        public int MntBase { get; set; }

        /// <summary>
        /// Monto base de márgenes de comercialización. Monto informado.
        /// Monto informado.
        /// </summary>
        public int MntMargenCom { get; set; }

        /// <summary>
        /// Tasa de IVA.
        /// 3 enteros, 2 decimales. (Ej: 19.5)
        /// </summary>
        public double TasaIVA { get; set; }

        /// <summary>
        /// Monto del IVA del DTE.
        /// Monto neto * Tasa IVA.
        /// </summary>
        public int IVA { get; set; }

        /// <summary>
        /// Monto del IVA propio.
        /// Las empresas que venden por cuenta de un mandatario.
        /// Pueden opcional separar el IVA en propio y de terceros.
        /// En todos estos casos el campo "IVA" debe contenerl el IVA total de la factura.
        /// </summary>
        public int IVAProp { get; set; }

        /// <summary>
        /// Monto del IVA de terceros.
        /// Las empresas que venden por cuenta de un mandatario.
        /// Pueden opcional separar el IVA en propio y de terceros.
        /// En todos estos casos el campo "IVA" debe contenerl el IVA total de la factura.
        /// </summary>
        public int IVATerc { get; set; }

        /// <summary>
        /// Impuestos y retenciones adicionales.
        /// </summary>
        public List<ImpuestosRetenciones>? ImptoReten { get; set; }

        /// <summary>
        /// IVA no retenido.
        /// Sólo en facturas de Compra en que hay retención de IVA por el emisor y Notas de Crédito o débito que referencian facturas de compra. 
        /// No se registra si es igual a 0.
        /// IVA - IVA retenido por producto.
        /// </summary>
        public int IVANoRet { get; set; }

        /// <summary>
        /// Crédito especial para empresas constructoras.
        /// Artículo 21 del decreto ley N° 910/75. 
        /// Este Es el único código que opera en forma opuesta al resto, ya que se resta al IVA general 
        /// </summary>
        public int CredEC { get; set; }

        /// <summary>
        /// Garantía por depósito de envases o embalajes.
        /// Sólo para empresas que usen envases en forma habitual, por su giro principal. Art.28,Inc3 Reglamento DL 825. (Cervezas, Jugos, Aguas Minerales, Bebidas Analcohólicas u otros autorizados por Resolución especial).
        /// Corresponde a la Sumatoria de las líneas de detalle que indican Indicador de facturación/exención = 3 (Detalle de garantía de depósito).
        /// </summary>
        public int GrntDep { get; set; }

        /// <summary>
        /// Comisiones y otros cargos. Es obligatorio para liquidaciones de factura.
        /// </summary>
        public List<Comisiones>? Comisiones { get; set; }

        /// <summary>
        /// Monto total del DTE.
        /// Monto neto + Monto no afecto o exento + IVA + Impuestos Adicionales + Impuestos Específicos + Iva Margen Comercialización + IVA Anticipado + Garantía por depósito de envases o embalajes - Crédito empresas constructoras - IVA Retenido productos (en caso de facturas de compra) - Valor Neto Comisiones y Otros Cargos - IVA Comisiones y Otros Cargos - Valor Comisiones y Otros Cargos No Afectos o Exentos.
        /// (Los Impuestos Adicionales y el IVA Anticipado están detallados en la TABLA de Impuestos Adicionales y Retenciones).
        /// En Documentos de exportación es “0” (cero) si forma de pago es = 21 (Sin pago).
        /// </summary>
        public double MntTotal { get; set; }

        /// <summary>
        /// Monto no facturable. 
        /// Corresponde a bienes o servicios facturados previamente.
        /// Suma de montos o bienes o servicios con indicador de facturación/exención = 2 (Producto o servicio no facturable positivo.) menos suma de montos de bienes o servicios con Indicador de facturación/exención = 6 (Producto o servicio no facturable negativo).
        /// </summary>
        public int MontoNF { get; set; }

        /// <summary>
        /// Total de ventas o servicios del periodo.
        /// Monto Total + Monto no Facturable
        /// </summary>
        public int MontoPeriodo { get; set; }

        /// <summary>
        /// Saldo anterior. Puede ser positivo o negativo.
        /// Se incluye sólo con fines de ilustrar con claridad el cobro.
        /// </summary>
        public int SaldoAnterior { get; set; }

        /// <summary>
        /// Valor a pagar total del documento.
        /// Valor cobrado.
        /// </summary>
        public int VlrPagar { get; set; }

        public Totales()
        {
            TpoMoneda = Enum.CodigosAduana.Moneda.NotSet;
            MntTotal = 0;
            MntNeto = 0;
            MntExe = 0;
            MntBase = 0;
            MntMargenCom = 0;
            TasaIVA = 0;
            IVA = 0;
            IVAProp = 0;
            IVATerc = 0;
            ImptoReten = null;
            IVANoRet = 0;
            CredEC = 0;
            GrntDep = 0;
            Comisiones = null;
            MontoNF = 0;
            MontoPeriodo = 0;
            SaldoAnterior = 0;
            VlrPagar = 0;
        }
    }
}
