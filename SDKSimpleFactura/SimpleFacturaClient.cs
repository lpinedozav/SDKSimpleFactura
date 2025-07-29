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
        public IBoletasHonorariosService BoletasHonorarios { get; }
        public IUsuariosService Usuarios { get; }

        public SimpleFacturaClient(ServiceProvider? serviceProvider = null) //Parametro para tests, NO ENVIAR EN PRODUCCION
        {
            var provider = serviceProvider ?? DependencyInjectionConfig.ConfigureServices();

            Facturacion = provider.GetRequiredService<IFacturacionService>();
            Productos = provider.GetRequiredService<IProductosService>();
            Proveedores = provider.GetRequiredService<IProveedoresService>();
            Clientes = provider.GetRequiredService<IClientesService>();
            Sucursal = provider.GetRequiredService<ISucursalService>();
            Folio = provider.GetRequiredService<IFolioService>();
            Configuracion = provider.GetRequiredService<IConfiguracionService>();
            BoletasHonorarios = provider.GetRequiredService<IBoletasHonorariosService>();
            Usuarios = provider.GetRequiredService<IUsuariosService>();
        }
    }
}
