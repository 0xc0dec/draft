using System.IO;
using Infrastructure.Config;
using Infrastructure.Hosting;
using Microsoft.AspNetCore.Hosting;

namespace Auth
{
    public class AuthProgram
    {
        public static void Main(string[] args)
        {
            var config = new AuthConfig(ConfigBuilder.Build(args, Directory.GetCurrentDirectory()));
            var host = HostBuilder.BuildWeb<AuthStartup, IAuthConfig>(config);
            host.Run();
        }
    }
}