using System.Threading.Tasks;

namespace Sample.Infrastructure.Repositories
{
    public interface IMongoRepository
    {
        Task<T> FindByIdAsync<T>(string id);
        Task<T> InsertAsync<T>(T item);
    }
}
