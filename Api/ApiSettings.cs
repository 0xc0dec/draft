using Infrastructure.Configuration;
using Infrastructure.Hosting;
using Microsoft.Extensions.Configuration;

namespace Api
{
    internal sealed class ApiSettings : WebHostSettings, IApiSettings
    {
        public string AuthorityUrl => cfg.GetString("authorityUrl");

        public ApiSettings(IConfiguration cfg) : base(cfg)
        {
        }
    }
}