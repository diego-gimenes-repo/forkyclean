
using System.Reflection;

using MediatR;
using ForkyAI.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ForkyAI.Domain.Interfaces;
using Orleans.Configuration;
using System.Net;

namespace Application.Configuration
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Adiciona MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // Adiciona serviços de infraestrutura
            services.AddScoped<IObservabilityService, ObservabilityService>();
            services.AddScoped<IRabbitMqService, RabbitMqService>();
            services.AddScoped<IQdrantService, QdrantService>();
            services.AddScoped<ISemanticKernelService, SemanticKernelService>();

            // Adiciona serviços de domínio
            services.AddScoped<IDomainEventService, DomainEventService>();
            services.AddScoped<IRepository<Grain>, GrainRepository>();

            // Adiciona Orleans
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

            return services;
        }
    }
}
