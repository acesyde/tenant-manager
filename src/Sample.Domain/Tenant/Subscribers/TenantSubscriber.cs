using Akka.Actor;
using Akkatecture.Aggregates;
using Akkatecture.Subscribers;
using Sample.Domain.Tenant.Events;
using System;
using System.Threading.Tasks;

namespace Sample.Domain.Tenant.Subscribers
{
    public class TenantSubscriber : DomainEventSubscriber
        , ISubscribeToAsync<TenantAggregate, TenantId, TenantCreatedEvent>
        , ISubscribeToAsync<TenantAggregate, TenantId, TenantArchivedEvent>
    {
        public IActorRef TenantRepository { get; }

        public TenantSubscriber(IActorRef tenantRepository)
        {
            TenantRepository = tenantRepository;
        }

        public Task HandleAsync(IDomainEvent<TenantAggregate, TenantId, TenantCreatedEvent> domainEvent)
        {
            throw new NotImplementedException();
        }

        public Task HandleAsync(IDomainEvent<TenantAggregate, TenantId, TenantArchivedEvent> domainEvent)
        {
            throw new NotImplementedException();
        }
    }
}
