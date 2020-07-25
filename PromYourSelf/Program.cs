using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Web.Administration;
using PromYourSelf.Data;
using Serilog;
using System;

namespace PromYourSelf
{
    public class Program
    {
        public static void Main(string[] args)
        {
          Log.Logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(Configuration) //Configuracion está declarado al final de este archivo.
                        .CreateLogger();

            Log.Information("Starting the web host.");

            try
            {
                // Build the application host
                var host = BuildWebHost(args);

                try
                {
                    using (var scope = host.Services.CreateScope())
                    {
                        var services = scope.ServiceProvider;
                        var serviceProvider = services.GetRequiredService<IServiceProvider>();
                        var configuration = services.GetRequiredService<IConfiguration>();
                        Seed.CreateUserAndRoles(serviceProvider).Wait();
                    }
                }
                catch (Exception exception)
                {
                    Log.Fatal(exception, "Se produjo un fallo creando usuario y rol basico.");
                }
                host.Run(); //Invoca el la funcion para corra el proyecto
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Se produjo u fallo tratando de iniciar el web host."); //Invoca el SeriLog
            }
            finally
            {
                Log.CloseAndFlush(); //Para hacer rolling al archivo de logs.
            }
            //CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>()
        .UseSerilog() //Para que incluya el SeriLog en todo el proyecto
        .Build();
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        /// <summary>
        /// Para seleccione un ambiente de desarrollo o de produccion.
        /// </summary>
        private static IConfiguration Configuration
        {
            get
            {
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                var builder = new ConfigurationBuilder();
                builder.AddJsonFile($"appsettings.{env}.json", false, true);

                builder.AddEnvironmentVariables();
                return builder.Build();
            }
        }
    }
}
