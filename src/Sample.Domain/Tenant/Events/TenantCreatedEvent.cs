using Akkatecture.Aggregates;

namespace Sample.Domain.Tenant.Events
{
    public class TenantCreatedEvent : AggregateEvent<TenantAggregate, TenantId>
    {
        public TenantCreatedEvent(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
