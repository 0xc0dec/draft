using Infrastructure.Hosting;
using Microsoft.Extensions.Configuration;

namespace Auth
{
    public class AuthConfig: WebHostConfig, IAuthConfig
    {
        public AuthConfig(IConfiguration cfg) : base(cfg)
        {
        }
    }
}