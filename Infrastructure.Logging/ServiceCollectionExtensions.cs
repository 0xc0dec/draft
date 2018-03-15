using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace Infrastructure.Logging
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection WithLogging(this IServiceCollection services, IConfiguration config)
        {
            var configSection = config.GetSection("serilog");

            var loggerCfg = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information);
            if (configSection != null && configSection.GetChildren().Any())
                loggerCfg.ReadFrom.ConfigurationSection(configSection);
            else
            {
                loggerCfg
                    .MinimumLevel.Debug()
                    .WriteTo.Console();
            }

            var logger = loggerCfg.CreateLogger();

            var factory = new LoggerFactory().AddSerilog(logger);
            services.AddSingleton(factory);
            services.AddLogging();

            return services;
        }
    }
}