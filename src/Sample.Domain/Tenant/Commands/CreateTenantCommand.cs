using Akkatecture.Commands;

namespace Sample.Domain.Tenant.Commands
{
    public class CreateTenantCommand : Command<TenantAggregate, TenantId>
    {
        public CreateTenantCommand(TenantId aggregateId, string name) : base(aggregateId)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
