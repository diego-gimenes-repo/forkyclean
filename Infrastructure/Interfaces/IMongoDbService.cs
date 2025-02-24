using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace ForkyAI.Infrastructure.Interfaces
{
    public interface IMongoDbService
    {
        IMongoCollection<T> GetCollection<T>(string name);
        Task InsertOneAsync<T>(T document);
        Task<IEnumerable<T>> FindAsync<T>(FilterDefinition<T> filter);
    }
}
