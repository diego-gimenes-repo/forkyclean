using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qdrant.Client.Grpc;

namespace ForkyAI.Infrastructure.Interfaces
{
    public interface IQdrantService
    {
        Task IndexVectorAsync<T>(string collectionName, T item) where T : class;
        Task<IEnumerable<T>> SearchAsync<T>(string collectionName, Filter filter) where T : class;
    }
}
