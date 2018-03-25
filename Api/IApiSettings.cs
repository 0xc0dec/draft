using Infrastructure.Hosting;

namespace Api
{
    internal interface IApiSettings: IWebHostSettings
    {
        string AuthorityUrl { get; }
    }
}