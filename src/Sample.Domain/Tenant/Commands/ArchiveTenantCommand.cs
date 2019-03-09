using Akkatecture.Commands;

namespace Sample.Domain.Tenant.Commands
{
    public class ArchiveTenantCommand : Command<TenantAggregate, TenantId>
    {
        public ArchiveTenantCommand(TenantId aggregateId) : base(aggregateId)
        {
        }
    }
}
