using Infrastructure.Config;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;

namespace Auth
{
    public class AuthConfig: IAuthConfig
    {
        [CanBeNull]
        public string BindUrl => cfg.TryGet("url");

        private readonly IConfiguration cfg;

        public AuthConfig(IConfiguration cfg)
        {
            this.cfg = cfg;
        }
    }
}