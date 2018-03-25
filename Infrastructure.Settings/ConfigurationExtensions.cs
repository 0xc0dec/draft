using System;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Configuration
{
    public static class ConfigurationExtensions
    {
        public static T Get<T>(this IConfiguration cfg, Func<IConfiguration, T> getter)
        {
            var val = getter(cfg);
            if (val == null)
                throw new ConfigurationException("Unable to get config value using custom getter");
            return val;
        }

        [CanBeNull]
        public static string TryGetString(this IConfiguration cfg, string path)
        {
            return cfg[path];
        }

        public static int? TryGetInt(this IConfiguration cfg, string path)
        {
            return int.TryParse(cfg.TryGetString(path), out var val) ? val : (int?) null;
        }

        public static string GetString(this IConfiguration cfg, string path)
        {
            var val = cfg.TryGetString(path);
            if (val == null)
                throw new ConfigurationException($"Configuration key '{path}' not found");
            return val;
        }
    }
}