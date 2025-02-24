using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForkyAI.Infrastructure.RabbitMq;
using Qdrant.Client.Grpc;

namespace ForkyAI.Infrastructure.Services
{
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
