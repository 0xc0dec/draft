using System.IO;
using Infrastructure.Config;
using Infrastructure.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Auth
{
    public class AuthProgram
    {
        public static void Main(string[] args)
        {
            var config = new AuthConfig(ConfigBuilder.Build(args, Directory.GetCurrentDirectory()));

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls(config.BindUrl ?? "http://*:12500")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseSetting("detailedErrors", "true")
                .ConfigureServices(services => services.AddSingleton<IAuthConfig>(config))
                .UseStartup<AuthStartup>()
                .UseLogging()
                .CaptureStartupErrors(true)
                .Build();
            host.Run();
        }
    }
}