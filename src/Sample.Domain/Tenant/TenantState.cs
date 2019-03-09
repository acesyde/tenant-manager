using Akkatecture.Aggregates;
using Sample.Domain.Tenant.Events;

namespace Sample.Domain.Tenant
{
    public class TenantState : AggregateState<TenantAggregate, TenantId>
        , IApply<TenantCreatedEvent>
        , IApply<TenantArchivedEvent>
    {
        public string Name { get; private set; }
        public bool IsArchived { get; private set; }

        public void Apply(TenantCreatedEvent aggregateEvent)
        {
            Name = aggregateEvent.Name;
            IsArchived = false;
        }

        public void Apply(TenantArchivedEvent aggregateEvent)
        {
            IsArchived = true;
        }
    }
}
