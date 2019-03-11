namespace Sample.Infrastructure
{
    public abstract class BaseEntity
    {
        public string Id { get; private set; }

        public BaseEntity(string id)
        {
            Id = id;
        }
    }
}
