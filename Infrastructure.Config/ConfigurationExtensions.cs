using System;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Config
{
    public static class ConfigurationExtensions
    {
        public static T Get<T>(this IConfiguration cfg, Func<IConfiguration, T> getter)
        {
            var val = getter(cfg);
            if (val == null)
                throw new ConfigException("Unable to get config value using custom getter");
            return val;
        }

        public static string Get(this IConfiguration cfg, string path)
        {
            var val = cfg[path];
            if (val == null)
                throw new ConfigException($"Configuration key '{path}' not found");
            return val;
        }
    }
}