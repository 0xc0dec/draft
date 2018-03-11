using System;
using JetBrains.Annotations;
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

        [CanBeNull]
        public static string TryGet(this IConfiguration cfg, string path)
        {
            return cfg[path];
        }

        public static int? TryGetInt(this IConfiguration cfg, string path)
        {
            return int.TryParse(cfg.TryGet(path), out var val) ? val : (int?) null;
        }

        public static string Get(this IConfiguration cfg, string path)
        {
            var val = cfg.TryGet(path);
            if (val == null)
                throw new ConfigException($"Configuration key '{path}' not found");
            return val;
        }
    }
}