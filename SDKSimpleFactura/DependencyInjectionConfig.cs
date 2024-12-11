using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using System.Text;
using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Services;
using System;
using System.IO;

namespace SDKSimpleFactura
{
    public static class DependencyInjectionConfig
    {
        public static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            services.AddSingleton<IConfiguration>(configuration);

            var baseUrl = configuration["SDKSettings:BaseUrl"];

            // Registrar AuthenticationService con la misma base URL
            services.AddHttpClient<IAuthenticationService, AuthenticationService>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });

            // Registrar DelegatingHandler
            services.AddTransient<AuthenticationDelegatingHandler>();

            // Registrar ApiService con DelegatingHandler y configurar la base URL
            services.AddHttpClient<IApiService, ApiService>(client =>
            {
                client.Timeout = TimeSpan.FromMinutes(5);
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            })
            .AddHttpMessageHandler<AuthenticationDelegatingHandler>();


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
