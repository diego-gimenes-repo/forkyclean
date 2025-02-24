using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MongoDB.Driver.Core.Connections;

namespace ForkyAI.Infrastructure.RabbitMq
{
    public class RabbitMqProducer : IRabbitMqProducer
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqProducer(string connectionString)
        {
            _connection = ConnectionFactory.CreateConnection(connectionString);
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare("forky_ai_exchange", ExchangeType.Direct);
        }

        public void Publish<T>(T message) where T : class
        {
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
            var properties = new BasicProperties
            {
                Persistence = true,
                Type = "text/json"
            };

            _channel.BasicPublish(exchange: "forky_ai_exchange",
                                routingKey: typeof(T).Name,
                                body: body,
                                properties: properties);
        }
    }

    // src/Infrastructure/Qdrant/QdrantService.cs
    public class QdrantService : IQdrantService
    {
        private readonly IQdrantClient _client;

        public QdrantService(string host)
        {
            _client = new QdrantClient(host);
        }

        public async Task IndexVectorAsync<T>(string collectionName, T item) where T : class
        {
            var points = new List<PointStruct>
        {
            new PointStruct
            {
                Id = (uint)item.GetHashCode(),
                Vector = GenerateVector(item),
                Payload = JsonSerializer.Serialize(item)
            }
        };

            await _client.UpdateCollectionAsync(
                collectionName,
                new UpdateCollectionParams
                {
                    Points = points
                });
        }

        private float[] GenerateVector<T>(T item)
        {
            // Implementação específica para seu caso de uso
            throw new NotImplementedException();
        }
    }
}
