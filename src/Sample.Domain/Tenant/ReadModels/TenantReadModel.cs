namespace Sample.Domain.Tenant.ReadModels
{
    public class TenantReadModel
    {
        public string Name { get; private set; }

        public TenantReadModel(string name)
        {
            Name = name;
        }
    }
}
