using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Core.Connections;
using static MongoDB.Driver.WriteConcern;

namespace ForkyAI.Infrastructure.Services
{
    public class RabbitMqService : IRabbitMqService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqService(string connectionString)
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
}
