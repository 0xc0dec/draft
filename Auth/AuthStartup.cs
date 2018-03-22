using Infrastructure.Logging;
using Infrastructure.Utils;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth
{
    internal sealed class AuthStartup
    {
        private readonly IConfiguration cfg;

        public AuthStartup(IConfiguration cfg)
        {
            this.cfg = cfg;
        }

        [UsedImplicitly]
        public void ConfigureServices(IServiceCollection services)
        {
            services.WithLogging(cfg);
            services.Configure<RouteOptions>(options => { options.LowercaseUrls = true; });
            services.AddMvc();

//            services.AddAuthentication()
//                .AddGoogle(options =>
//                {
//                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme; 
//                    // TODO client id
//                });

            var cert = SigningCertificate.Create(GetType().Assembly.GetEmbeddedFile("dev.pfx"), "123456"); // TODO
            services.AddIdentityServer()
                .AddSigningCredential(cert)
                .AddInMemoryApiResources(IdentityServerDefs.Resources)
                .AddInMemoryClients(IdentityServerDefs.Clients);
        }

        [UsedImplicitly]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseIdentityServer();
            app.UseMvc();
        }
    }
}