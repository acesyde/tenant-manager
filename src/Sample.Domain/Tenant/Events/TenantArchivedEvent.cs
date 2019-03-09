using Akkatecture.Aggregates;

namespace Sample.Domain.Tenant.Events
{
    public class TenantArchivedEvent : AggregateEvent<TenantAggregate, TenantId>
    {
        public TenantArchivedEvent()
        {
        }
    }
}
