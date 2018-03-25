using Infrastructure.Hosting;

namespace Api
{
    internal interface IApiConfig: IWebHostConfig
    {
        string AuthorityUrl { get; }
    }
}