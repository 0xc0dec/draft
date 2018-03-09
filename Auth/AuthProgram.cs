using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Auth
{
    public class AuthProgram
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseSetting("detailedErrors", "true")
                .UseStartup<AuthStartup>()
                .CaptureStartupErrors(true)
                .Build();
            host.Run();
        }
    }
}