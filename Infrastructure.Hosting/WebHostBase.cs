using System.IO;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Hosting
{
    public abstract class WebHostBase
    {
        protected abstract string BindUrl { get; }
        
        protected IConfiguration Config { get; }

        protected abstract void ConfigureServices(WebHostBuilderContext context, IServiceCollection services);
        protected abstract void Configure(IApplicationBuilder app);

        protected WebHostBase(string[] cmd)
        {
            Config = ConfigBuilder.Build(cmd, Directory.GetCurrentDirectory());
        }

        public void Run()
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls(BindUrl)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseSetting("detailedErrors", "true")
                .ConfigureServices(ConfigureServices)
                .Configure(Configure)
                .CaptureStartupErrors(true)
                .Build();
            host.Run();
        }
    }
}