using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Sample.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Mongo
{
    public class MongoRepository : IMongoRepository
    {
        private readonly IMongoDatabase _database;

        public MongoRepository(IOptions<Settings> options)
        {
            _database = new MongoClient(options?.Value?.ConnectionString).GetDatabase(options?.Value?.Database);
        }

        public async Task<T> FindByIdAsync<T>(string id) where T : BaseEntity
        {
            return await _database.GetCollection<T>(nameof(T)).Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task InsertAsync<T>(T item) where T : BaseEntity
        {
            await _database.GetCollection<T>(nameof(T)).InsertOneAsync(item);
        }
    }
}
