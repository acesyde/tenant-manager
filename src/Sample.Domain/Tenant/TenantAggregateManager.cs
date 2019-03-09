using Akkatecture.Aggregates;
using Akkatecture.Commands;

namespace Sample.Domain.Tenant
{
    public class TenantAggregateManager : AggregateManager<TenantAggregate, TenantId, Command<TenantAggregate, TenantId>>
    {
    }
}
