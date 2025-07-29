using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SDKSimpleFactura.Interfaces;
using SDKSimpleFactura.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SDKSimpleFacturaTests.Utilidades
{
    public static class TestDependencyInjectionConfig
    {
        public static ServiceProvider ConfigureTestServices()
        {
            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Test.json", optional: false)
                .Build();

            services.AddSingleton<IConfiguration>(configuration);

            var baseUrl = configuration["SDKSettings:BaseUrl"];

            services.AddHttpClient<IAuthenticationService, AuthenticationService>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });

            services.AddTransient<AuthenticationDelegatingHandler>();

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
            services.AddTransient<IUsuariosService, UsuariosService>();

            var provider = services.BuildServiceProvider();

            // Obtener token desde authService e inyectarlo en appsettings.Test.json
            var auth = provider.GetRequiredService<IAuthenticationService>();
            var token = auth.GetTokenAsync().GetAwaiter().GetResult();

            var newExpiresAt = DateTime.UtcNow.AddMinutes(30); // O usa lo que devuelva tu backend
            var configPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Test.json");

            var json = File.ReadAllText(configPath);
            var jObj = Newtonsoft.Json.Linq.JObject.Parse(json);

            jObj["SDKSettings"]["AccessToken"] = token;
            jObj["SDKSettings"]["ExpiresAt"] = newExpiresAt.ToString("o");

            File.WriteAllText(configPath, jObj.ToString());

            return provider;
        }
    }

}
