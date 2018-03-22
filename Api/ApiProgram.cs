using System.IO;
using Infrastructure.Config;
using Infrastructure.Hosting;
using Microsoft.AspNetCore.Hosting;

namespace Api
{
    internal sealed class ApiProgram
    {
        public static void Main(string[] args)
        {
            var config = new ApiConfig(ConfigBuilder.Build(args, Directory.GetCurrentDirectory()));
            var host = HostBuilder.BuildWeb<ApiStartup, IApiConfig>(config);
            host.Run();
        }
    }
}