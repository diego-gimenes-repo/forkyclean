using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForkyAI.Infrastructure.Interfaces
{
    public interface IRabbitMqService
    {
        void Publish<T>(T message) where T : class;
        void Subscribe<T>(string queueName, Action<T> handler) where T : class;
    }
}
