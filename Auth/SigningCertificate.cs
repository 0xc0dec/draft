using System.Security.Cryptography.X509Certificates;

namespace Auth
{
    public static class SigningCertificate
    {
        public static X509Certificate2 Create(byte[] content, string pass)
        {
            return new X509Certificate2(content, pass, X509KeyStorageFlags.UserKeySet);
        }
    }
}