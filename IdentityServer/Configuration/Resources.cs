
using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

using System.Collections.Generic;

namespace IdentityServer.Configuration
{
    public static class Resources
    {



        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                // backward compat
                new ApiScope("ApiOne","Api One"),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources() =>
        new List<ApiResource> {
            new ApiResource("ApiOne", new string[] { "read", "write" }),
        };

        public static IEnumerable<IdentityResource> GetIdentityResources() =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),

        };


        public static IEnumerable<Client> GetClients() =>
        new List<Client> {

            new Client {

                ClientId = "client_id",
                ClientSecrets = { new Secret("client_secret".ToSha256()) },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "ApiOne" }
            },

            new Client {

                ClientId = "client_id_mvc",
                //ClientSecrets = { new Secret("client_secret_mvc".ToSha256()) },

                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                RequireClientSecret = false,

                // puts all the claims in the id token
                //AlwaysIncludeUserClaimsInIdToken = true,
                AllowOfflineAccess = true,
                RequireConsent = false,

                RedirectUris = { "https://localhost:4001/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:4001/signout-oidc" },
                AllowedCorsOrigins = {"https://localhost:4001"},

                AllowedScopes = {
                    "ApiOne",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                },
            },

        };
    }
}
