using Sample.Infrastructure;

namespace Sample.Domain.Tenant.ReadModels
{
    public class TenantReadModel : BaseEntity
    {
        public string Name { get; private set; }

        public TenantReadModel(string id, string name)
            : base(id)
        {
            Name = name;
        }
    }
}
