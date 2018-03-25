using System.IO;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Configuration
{
    public static class ConfigBuilder
    {
        public static IConfigurationRoot Build(string[] cmd, string workingDir)
        {
            return new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(workingDir, "settings.json"), true, true)
                .AddJsonFile(Path.Combine(workingDir, "settings.local.json"), true, true)
                .AddCommandLine(cmd)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}