using Akka.Actor;
using Sample.Domain.Tenant.Queries;
using Sample.Domain.Tenant.ReadModels;
using Sample.Infrastructure.Repositories;

namespace Sample.Domain.Tenant.Repositories
{
    public class TenantRepository : ReceiveActor
    {
        private readonly IMongoRepository _mongoRepository;

        public TenantRepository(IMongoRepository mongoRepository)
        {
            _mongoRepository = mongoRepository;

            Receive<GetTenantQuery>(Handle);
        }

        private bool Handle(GetTenantQuery query)
        {
            var result = _mongoRepository.FindByIdAsync<TenantReadModel>(query.Id);
            Sender.Tell(result);
            return true;
        }
    }
}
