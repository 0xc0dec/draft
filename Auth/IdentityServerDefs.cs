using IdentityServer4.Models;

namespace Auth
{
    internal static class IdentityServerDefs
    {
        public static ApiResource[] Resources { get; } = 
        {
            new ApiResource("some_api", "Some API")
        };

        public static Client[] Clients { get; } =
        {
            new Client
            {
                ClientId = "some_client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("c4a0e19a-cfc3-42a2-b148-cc5ba964cd00".Sha256())
                },
                AllowedScopes =
                {
                    "some_api"
                } 
            }
        };
    }
}