using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace ForkyAI.Infrastructure.Services
{
    public class MongoDbService : IMongoDbService
    {
        private readonly MongoClient _client;
        private readonly string _databaseName;

        public MongoDbService(IConfiguration configuration)
        {
            _client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            _databaseName = configuration["MongoDb:DatabaseName"];
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            var database = _client.GetDatabase(_databaseName);
            return database.GetCollection<T>(name);
        }
    }


}
