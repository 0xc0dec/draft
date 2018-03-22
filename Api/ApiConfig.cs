using Infrastructure.Hosting;
using Microsoft.Extensions.Configuration;

namespace Api
{
    internal sealed class ApiConfig : WebHostConfig, IApiConfig
    {
        public ApiConfig(IConfiguration cfg) : base(cfg)
        {
        }
    }
}