using Akka.Actor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sample.Domain.Tenant;
using Sample.Domain.Tenant.Repositories;
using Sample.Domain.Tenant.Subscribers;
using Sample.Infrastructure.Mongo;
using Sample.Infrastructure.Repositories;

namespace Sample.Host
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterAkka(services);

            services.AddScoped<IMongoRepository, MongoRepository>();
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        private static void RegisterAkka(IServiceCollection services)
        {
            var actorSystem = ActorSystem.Create("api-system");

            services
                .AddAkkatecture(actorSystem);

            services.AddSingleton<Domain.TenantAggregateManagerActorProvider>(provider =>
            {
                var system = provider.GetService<ActorSystem>();
                var tenantAggregateManager = system.ActorOf(Props.Create(() => new TenantAggregateManager()), "tenant-manager");
                return () => tenantAggregateManager;
            });

            services.AddSingleton<Domain.TenantRepositoryActorProvider>(provider =>
            {
                var system = provider.GetService<ActorSystem>();
                var tenantRepository = system.ActorOf(Props.Create(() => new TenantRepository(provider.GetService<IMongoRepository>())), "tenant-repository");
                return () => tenantRepository;
            });

            services.AddSingleton<Domain.TenantSubscriberActorProvider>(provider =>
            {
                var system = provider.GetService<ActorSystem>();
                var tenantSubscriber = system.ActorOf(Props.Create(() => new TenantSubscriber(provider.GetService<Domain.TenantRepositoryActorProvider>().Invoke())), "tenant-subscriber");
                return () => tenantSubscriber;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
