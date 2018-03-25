using JetBrains.Annotations;

namespace Infrastructure.Hosting
{
    public interface IWebHostSettings
    {
        [CanBeNull]
        string BindUrl { get; }
    }
}