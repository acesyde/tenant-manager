using Sample.Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Mongo
{
    public class MongoRepository : IMongoRepository
    {
        public Task<T> FindByIdAsync<T>(string id)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync<T>(T item)
        {
            throw new NotImplementedException();
        }
    }
}
