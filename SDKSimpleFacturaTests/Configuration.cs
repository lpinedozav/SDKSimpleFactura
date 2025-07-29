using Microsoft.Extensions.Configuration;

public static class Configuracion
{
    private static readonly IConfiguration _configuration;

    static Configuracion()
    {
        _configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.Test.json", optional: false, reloadOnChange: true)
            .Build();
    }

    public static string Usuario => _configuration["Credenciales:Usuario"];
    public static string Contrasena => _configuration["Credenciales:Contrasena"];
}
