using Infrastructure.Config;
using Infrastructure.Hosting;
using Microsoft.Extensions.Configuration;

namespace Api
{
    internal sealed class ApiConfig : WebHostConfig, IApiConfig
    {
        public string AuthorityUrl => cfg.GetString("authorityUrl");

        public ApiConfig(IConfiguration cfg) : base(cfg)
        {
        }
    }
}