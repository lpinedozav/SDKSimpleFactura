using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKSimpleFactura.Models.Facturacion
{
    public class Documento
    {
        public string? Id { get; set; }

        /// <summary>
        /// Identificación y totales del documento.
        /// </summary>
        public Encabezado? Encabezado { get; set; }

        /// <summary>
        /// Detalle de ítemes del DTE.
        /// Corresponde a la información de un ítem. Debe ir al menos una línea de detalle. El máximo de ítems es de 60 y en un documento se puede incluir sólo la cantidad de ítems que se pueda imprimir en una hoja, respetando la normativa de impresión del SII.
        /// </summary>
        public List<Detalle> Detalle { get; set; }

        /// <summary>
        /// Subtotales informativos.
        /// Pueden ser de 0 hasta 20 líneas. 
        /// Estos subtotales no aumentan o disminuyen la base del impuesto, ni modifican los campos totalizadores, sólo son campos informativos.
        /// Estos subtotales tienen una glosa que especifica el concepto. Por ejemplo un subtotal aplicado a un determinado grupo de productos, servicios o elementos.
        /// En la representación impresa, estos subtotalizadores pueden intercalarse entre las líneas de detalle, o indicarse en forma agrupada en una sección aparte.
        /// </summary>
        public List<SubTotal> SubTotInfo { get; set; }

        /// <summary>
        /// Descuentos y/o recargos que afecta al total del documento.
        /// Pueden ser de 0 hasta 20 líneas. Estos aumentan o disminuyen la base del impuesto.
        /// Estos descuentos o recargos tienen una glosa que especifica el concepto. Por ejemplo un descuento global aplicado a un determinado tipo de producto o un descuento por pago contado que afecta a todos los ítems.
        /// En caso que se apliquen descuentos o recargos globales y: 
        /// a) en la Zona de Detalle hayan ítems con distintos códigos de impuesto o retenciones, el campo “tipo de valor” del descuento debe ser %.
        /// b) En la Zona de Detalle hayan algunos ítems afectos, otros exentos y otros no facturables (con “Indicador de Facturación Exención”=1 o 2), hay tres casos:
        ///    - Si el descuento afecta sólo a los ítems exentos se debe indicar un 1 en el “Indicador de Facturación/Exención”.
        ///    - Si el descuento afecta sólo a los ítems afectos no debe llevar el “Indicador de Facturación/Exención”.
        ///    - Si el descuento/recargo afecta sólo a los ítems no facturables se debe indicar un 2 en el “Indicador de Facturación/exención”.
        ///    - Si el descuento afecta a todos, deben haber tres líneas: Una con el descuento para el descuento de los afectos, otra para el descuento de los exentos y otra para los no facturables.

        /// </summary>
        public List<DescuentosRecargos>? DscRcgGlobal { get; set; }

        /// <summary>
        /// Identificación de otros documentos referenciadas por este documento.
        /// Máximo 40.
        /// </summary>
        public List<Referencia>? Referencia { get; set; }

        /// <summary>
        /// Comisiones y otros cargos.
        /// Es obligatoria para liquidaciones de factura.
        /// Máximo 20.
        ///  No modifican la base del impuesto de la operación principal.
        ///  Se incorpora en caso que se apliquen comisiones/otros cargos. 
        ///  Obligatoriamente en Liquidaciones-Factura Electrónicas y opcionalmente en Facturas de Compra Electrónica, o en Notas de Crédito/Débito Electrónicas que corrijan Facturas de Compra. 
        /// </summary>
        public List<ComisionRecargo>? Comisiones { get; set; }

        public Documento()
        {
            Encabezado = new Encabezado();
            Detalle = new List<Detalle>();

            SubTotInfo = new List<SubTotal>();
            DscRcgGlobal = new List<DescuentosRecargos>();
            Referencia = new List<Referencia>();
            Comisiones = new List<ComisionRecargo>();
        }
    }
}
