using Infrastructure.Hosting;
using Microsoft.Extensions.Configuration;

namespace Auth
{
    internal sealed class AuthSettings: WebHostSettings, IAuthSettings
    {
        public AuthSettings(IConfiguration cfg) : base(cfg)
        {
        }
    }
}