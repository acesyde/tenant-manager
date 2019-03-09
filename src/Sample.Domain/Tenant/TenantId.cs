using Akkatecture.Core;

namespace Sample.Domain.Tenant
{
    public class TenantId : Identity<TenantId>
    {
        public TenantId(string value) : base(value)
        {
        }
    }
}
