
using System.Net;
using Application.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;

class Program
{
    static async Task Main(string[] args)
    {
        // Configuração do ambiente
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

        // Configuração
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        // Serviços
        var services = new ServiceCollection();
        services.AddApplicationServices();

        // Orleans
        services.AddOrleansClient(builder =>
        {
            builder
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "forky_ai_cluster";
                    options.ServiceId = "forky_ai";
                })
                .Configure<EndpointOptions>(options =>
                {
                    options.AdvertisedIPAddress = IPAddress.Loopback;
                    options.GatewayPort = 30000;
                    options.SiloPort = 11111;
                });
        });

        // Inicializa o cliente Orleans
        var client = services.BuildServiceProvider()
            .GetRequiredService<IClusterClient>();

        try
        {
            await client.Connect(async ex =>
            {
                Console.WriteLine($"Erro de reconexão: {ex.Message}");
                return true;
            });

            Console.WriteLine("Cliente Orleans conectado com sucesso. Pressione qualquer tecla para encerrar...");
            await Task.Run(() => Console.ReadKey());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao conectar ao cluster: {ex.Message}");
            throw;
        }
        finally
        {
            await client.DisposeAsync();
        }
    }
}