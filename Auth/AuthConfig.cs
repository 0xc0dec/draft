using Infrastructure.Hosting;
using Microsoft.Extensions.Configuration;

namespace Auth
{
    internal sealed class AuthConfig: WebHostConfig, IAuthConfig
    {
        public AuthConfig(IConfiguration cfg) : base(cfg)
        {
        }
    }
}