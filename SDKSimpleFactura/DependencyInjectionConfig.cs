using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using System.Text;
using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Services;

namespace SDKSimpleFactura
{
    public static class DependencyInjectionConfig
    {
        public static ServiceProvider ConfigureServices(string username, string password)
        {
            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            services.AddSingleton<IConfiguration>(configuration);

            services.AddHttpClient<IApiService, ApiService>(client =>
            {
                client.Timeout = TimeSpan.FromMinutes(5);
                client.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]);

                var authToken = Encoding.ASCII.GetBytes($"{username}:{password}");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            services.AddTransient<IFacturacionService, FacturacionService>();
            services.AddTransient<IProductosService, ProductosService>();
            services.AddTransient<IProveedoresService, ProveedoresService>();
            services.AddTransient<IClientesService, ClientesService>();
            services.AddTransient<ISucursalService, SucursalService>();
            services.AddTransient<IFolioService, FolioService>();
            services.AddTransient<IConfiguracionService, ConfiguracionService>();
            services.AddTransient<IBoletasHonorariosService, BoletasHonorariosService>();
            return services.BuildServiceProvider();
        }
    }
}
