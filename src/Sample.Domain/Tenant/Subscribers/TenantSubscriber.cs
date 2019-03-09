using Akkatecture.Aggregates;
using Akkatecture.Subscribers;
using Sample.Domain.Tenant.Events;
using Sample.Domain.Tenant.Queries;
using Sample.Domain.Tenant.ReadModels;
using Sample.Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace Sample.Domain.Tenant.Subscribers
{
    public class TenantSubscriber : DomainEventSubscriber
        , ISubscribeToAsync<TenantAggregate, TenantId, TenantCreatedEvent>
        , ISubscribeToAsync<TenantAggregate, TenantId, TenantArchivedEvent>
    {
        private readonly IMongoRepository _mongoRepository;

        public TenantSubscriber(IMongoRepository mongoRepository)
        {
            _mongoRepository = mongoRepository;

            ReceiveAsync<GetTenantQuery>(Handle);
        }

        public async Task HandleAsync(IDomainEvent<TenantAggregate, TenantId, TenantCreatedEvent> domainEvent)
        {
            await _mongoRepository.InsertAsync(new TenantReadModel(domainEvent.AggregateEvent.Name));
        }

        public Task HandleAsync(IDomainEvent<TenantAggregate, TenantId, TenantArchivedEvent> domainEvent)
        {
            throw new NotImplementedException();
        }

        private async Task Handle(GetTenantQuery arg)
        {
            await _mongoRepository.FindByIdAsync<TenantReadModel>(arg.Id);
        }
    }
}
