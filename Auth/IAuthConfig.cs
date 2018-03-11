using JetBrains.Annotations;

namespace Auth
{
    public interface IAuthConfig
    {
        int? Port { get; }
        
        [CanBeNull]
        string BindUrl { get; }
    }
}