using Akka.Actor;

namespace Sample.Domain
{
    public delegate IActorRef TenantAggregateManagerActorProvider();
    public delegate IActorRef TenantRepositoryActorProvider();
    public delegate IActorRef TenantSubscriberActorProvider();
}
