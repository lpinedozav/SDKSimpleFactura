# SDK SimpleFactura

El **SDK SimpleFactura** es una solución en C# diseñada para facilitar la integración con los servicios de **SimpleFactura**, parte de ChileSystems. Este SDK provee un conjunto de clases y métodos que permiten realizar operaciones como facturación, gestión de productos, proveedores, clientes, sucursales, folios, configuración y boletas de honorarios.

## Características principales

- Simplifica la interacción con los servicios de SimpleFactura.
- Proporciona interfaces específicas para operaciones como:
  - **Facturación:** Generación y gestión de documentos tributarios electrónicos.
  - **Gestión de productos, proveedores y clientes.**
  - **Configuración de sucursales y folios.**
  - **Emisión de boletas de honorarios.**
- Compatible con aplicaciones en .NET Standard 2.0.

## Requisitos

### Dependencias
Al instalar el SDK a través de NuGet, las dependencias se gestionarán automáticamente. Las principales son:

- **Microsoft.Extensions.DependencyInjection**
- **Newtonsoft.Json 13.0.1**
- **NETStandard.Library 2.0.3**

### Plataforma
El SDK es compatible con proyectos que soporten **.NET Standard 2.0**.

## Instalación

### Usando NuGet CLI

```bash
nuget install SDKSimpleFactura
```
### Desde Package Manager en Visual Studio

```bash
PM> Install-Package SDKSimpleFactura
```

### Usando .NET CLI
```bash
dotnet add package SDKSimpleFactura
```

### Desde Visual Studio:

1. Abrir el explorador de soluciones.
2. Clic derecho en un proyecto dentro de tu solución.
3. Clic en Administrar paquetes NuGet.
4. Clic en la pestaña Examinar y busque `SDKSimpleFactura`
5. Clic en el paquete `SDKSimpleFactura`, seleccione la versión que desea utilizar y finalmente selecciones instalar.

### Cómo empezar
Para utilizar el SDK, simplemente inicializa la clase SimpleFacturaClient proporcionando tu nombre de usuario y contraseña:
```ruby
using SDKSimpleFactura;

class Program
{
    static void Main()
    {
        var SimpleFacturaClient = new SimpleFacturaClient("usuario", "contraseña");
        // Ejemplo: Uso de los servicios
        var facturacionService = SimpleFacturaClient.Facturacion;
        var productosService = SimpleFacturaClient.Productos;
        var proveedoresService = SimpleFacturaClient.Proveedores;
        var clientesService = SimpleFacturaClient.Clientes;
        var sucursalService = SimpleFacturaClient.Sucursal;
        var folioService = SimpleFacturaClient.Folio;
        var configuracionService = SimpleFacturaClient.Configuracion;
        var boletaHonorariosService = SimpleFacturaClient.BoletasHonorarios;
    }
}
```

### Documentación
Puedes encontrar toda la documentación de cómo usar este SDK en el sitio https://www.simplefactura.cl.
