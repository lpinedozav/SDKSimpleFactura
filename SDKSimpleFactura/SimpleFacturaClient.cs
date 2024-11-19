using Microsoft.Extensions.DependencyInjection;
using SDKSimpleFactura.Interfaces;

namespace SDKSimpleFactura
{
    public class SimpleFacturaClient
    {
        public IFacturacionService Facturacion { get; }
        public IProductosService Productos { get; }
        public IProveedoresService Proveedores { get; }
        public IClientesService Clientes { get; }
        public ISucursalService Sucursal { get; }
        public IFolioService Folio { get; }
        public IConfiguracionService Configuracion { get; }
        public IBoletasHonorariosService BoletasHonorariosService { get; }

        public SimpleFacturaClient(string username, string password)
        {
            var serviceProvider = DependencyInjectionConfig.ConfigureServices(username, password);

            Facturacion = serviceProvider.GetRequiredService<IFacturacionService>();
            Productos = serviceProvider.GetRequiredService<IProductosService>();
            Proveedores = serviceProvider.GetRequiredService<IProveedoresService>();
            Clientes = serviceProvider.GetRequiredService<IClientesService>();
            Sucursal = serviceProvider.GetRequiredService<ISucursalService>();
            Folio = serviceProvider.GetRequiredService<IFolioService>();
            Configuracion = serviceProvider.GetRequiredService<IConfiguracionService>();
            BoletasHonorariosService = serviceProvider.GetRequiredService<IBoletasHonorariosService>();
        }
    }
}
