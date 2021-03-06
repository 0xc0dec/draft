﻿using Infrastructure.Hosting;
using Infrastructure.Logging;
using Infrastructure.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Auth
{
    internal sealed class AuthHost: WebHostBase
    {
        private readonly AuthSettings settings;

        protected override string BindUrl => settings.BindUrl ?? "http://0.0.0.0:12000";

        public AuthHost(string[] cmd): base(cmd)
        {
            settings = new AuthSettings(Config);
        }

        protected override void ConfigureServices(WebHostBuilderContext context, IServiceCollection services)
        {
            services.WithLogging(Config);
            services.Configure<RouteOptions>(options => { options.LowercaseUrls = true; });
            services.AddMvc();

//            services.AddAuthentication()
//                .AddGoogle(options =>
//                {
//                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme; 
//                    // TODO client id
//                });

//            var cert = SigningCertificate.Create(GetType().Assembly.GetEmbeddedFile("dev.pfx"), "123456"); // TODO
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(IdentityServerDefs.Resources)
                .AddInMemoryClients(IdentityServerDefs.Clients);
        }

        protected override void Configure(IApplicationBuilder app)
        {
            // TODO
//            if (env.IsDevelopment())
//                app.UseDeveloperExceptionPage();
            
            app.UseIdentityServer();
            app.UseMvc();
        }
    }
}