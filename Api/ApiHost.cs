using System;
using Infrastructure.Hosting;
using Infrastructure.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    public class ApiHost: HostBase
    {
        private readonly IApiConfig config;

        protected override string BindUrl => config.BindUrl ?? "http://0.0.0.0:12001";

        public ApiHost(string[] cmd): base(cmd)
        {
            config = new ApiConfig(Config);
        }

        protected override void ConfigureServices(WebHostBuilderContext context, IServiceCollection services)
        {
            services.AddSingleton(config);
            services.WithLogging(Config);
            
            services.AddMvc();
            services.AddAuthorization();

            var serviceProvider = services.BuildServiceProvider();

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddIdentityServerAuthentication(options =>
                {
                    options.EnableCaching = true;
                    options.CacheDuration = TimeSpan.FromHours(1);
                    options.Authority = config.AuthorityUrl;
                    options.RequireHttpsMetadata = false; // TODO?
                    options.LegacyAudienceValidation = false;
                });
        }

        protected override void Configure(IApplicationBuilder app)
        {
//            if (env.IsDevelopment())
//                app.UseDeveloperExceptionPage();

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}