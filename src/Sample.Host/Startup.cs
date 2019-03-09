using Akka.Actor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sample.Domain.Tenant;

namespace Sample.Host
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var actorSystem = ActorSystem.Create("api-system");
            var tenantManager = actorSystem.ActorOf(Props.Create(() => new TenantAggregateManager()), "tenant-manager");
            services
                .AddAkkatecture(actorSystem)
                .AddActorReference<TenantAggregateManager>(tenantManager);

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
