using Infrastructure.Configuration;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Hosting
{
    public class WebHostSettings: IWebHostSettings
    {
        [CanBeNull]
        public string BindUrl => cfg.TryGetString("url");

        protected readonly IConfiguration cfg;

        public WebHostSettings(IConfiguration cfg)
        {
            this.cfg = cfg;
        }
    }
}