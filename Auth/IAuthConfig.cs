using JetBrains.Annotations;

namespace Auth
{
    public interface IAuthConfig
    {
        [CanBeNull]
        string BindUrl { get; }
    }
}