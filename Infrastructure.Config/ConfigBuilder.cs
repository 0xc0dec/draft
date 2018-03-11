using System.IO;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Config
{
    public static class ConfigBuilder
    {
        public static IConfigurationRoot Build(string[] cmdArgs, string workingDir)
        {
            return new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(workingDir, "config.json"), true, true)
                .AddJsonFile(Path.Combine(workingDir, "config.local.json"), true, true)
                .AddCommandLine(cmdArgs)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}