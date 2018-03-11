using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;

namespace Infrastructure.Logging
{
    public static class LoggingExtensions
    {
        public static IWebHostBuilder UseLogging(this IWebHostBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            return builder.UseSerilog();            
        }
    }
}