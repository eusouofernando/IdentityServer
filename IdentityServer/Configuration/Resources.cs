
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
                new ApiScope("ApiOne"),
                new ApiScope("ApiTwo")
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources() =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            //new IdentityResources.Profile(),
            new IdentityResource
            {
                Name = "rc.scope",
                UserClaims =
                {
                    "rc.garndma"
                }
            }
        };

        public static IEnumerable<ApiResource> GetApiResources() =>
        new List<ApiResource> {
            new ApiResource("ApiOne", new string[] { "read", "write" }),
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
                ClientSecrets = { new Secret("client_secret_mvc".ToSha256()) },

                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,

                RedirectUris = { "https://localhost:4001/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:4001/Home/Index" },

                AllowedScopes = {
                    "ApiOne",
                    "ApiTwo",
                    IdentityServerConstants.StandardScopes.OpenId,
                    //IdentityServerConstants.StandardScopes.Profile,
                    "rc.scope",
                },

                // puts all the claims in the id token
                //AlwaysIncludeUserClaimsInIdToken = true,
                AllowOfflineAccess = true,
                RequireConsent = false,
            },

        };
    }
}
