using JetBrains.Annotations;

namespace Infrastructure.Hosting
{
    public interface IWebHostConfig
    {
        [CanBeNull]
        string BindUrl { get; }
    }
}