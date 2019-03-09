using Akkatecture.Aggregates;

namespace Sample.Domain.Tenant
{
    public class TenantAggregate : AggregateRoot<TenantAggregate, TenantId, TenantState>
    {
        public TenantAggregate(TenantId id) : base(id)
        {
        }
    }
}
