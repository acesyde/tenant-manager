using System.Threading.Tasks;

namespace Sample.Infrastructure.Repositories
{
    public interface IMongoRepository
    {
        Task<T> FindByIdAsync<T>(string id) where T : BaseEntity;
        Task InsertAsync<T>(T item) where T : BaseEntity;
    }
}
