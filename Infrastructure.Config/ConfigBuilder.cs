using Microsoft.Extensions.Configuration;

namespace Infrastructure.Config
{
    public static class ConfigBuilder
    {
        public static IConfigurationRoot Build(string[] cmdArgs)
        {
            return new ConfigurationBuilder()
                .AddJsonFile("config.json", true, true)
                .AddJsonFile("config.local.json", true, true)
                .AddCommandLine(cmdArgs)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}