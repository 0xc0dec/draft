using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Hosting
{
    public static class HostBuilder
    {
        public static IWebHost BuildWeb<TStartup, TConfig>(TConfig config)
            where TStartup: class 
            where TConfig: class, IWebHostConfig 
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls(config.BindUrl ?? "http://0.0.0.0:12500")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseSetting("detailedErrors", "true")
                .ConfigureServices(services => services.AddSingleton(config))
                .UseStartup<TStartup>()
                .CaptureStartupErrors(true)
                .Build();
            return host;
        }
    }
}