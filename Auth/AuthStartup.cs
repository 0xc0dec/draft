using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth
{
    public class AuthStartup
    {
        private readonly IConfiguration cfg;

        public AuthStartup(IConfiguration cfg)
        {
            this.cfg = cfg;
        }

        [UsedImplicitly]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        [UsedImplicitly]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
        }
    }
}