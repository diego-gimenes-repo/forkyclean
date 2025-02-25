using System;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orleans;

namespace ForkyAI.Infrastructure.Services
{
    public class OrleansService : IHostedService
    {
        private readonly IClusterClient _clusterClient;
        private readonly ILogger<OrleansService> _logger;

        public OrleansService(IClusterClient clusterClient, ILogger<OrleansService> logger)
        {
            _clusterClient = clusterClient;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Inicializando Orleans Service");
                await _clusterClient.Connect(cancellationToken);
                _logger.LogInformation("Orleans Service conectado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao iniciar Orleans Service");
                throw;
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            object value = await _clusterClient.Close();
            _logger.LogInformation("Orleans Service parado");
        }
    }
}
