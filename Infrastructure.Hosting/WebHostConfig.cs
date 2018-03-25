using Infrastructure.Config;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Hosting
{
    public class WebHostConfig: IWebHostConfig
    {
        [CanBeNull]
        public string BindUrl => cfg.TryGetString("url");

        protected readonly IConfiguration cfg;

        public WebHostConfig(IConfiguration cfg)
        {
            this.cfg = cfg;
        }
    }
}