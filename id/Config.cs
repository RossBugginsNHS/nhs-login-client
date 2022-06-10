using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace id;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
             new IdentityResources.Profile()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
          new List<ApiScope>
        {
            new ApiScope("api1", "My API")
        };

    public static IEnumerable<Client> Clients =>
            new List<Client>
    {

        new Client
        {
            ClientId = "client",

            // no interactive user, use the clientid/secret for authentication
            AllowedGrantTypes =
             { OidcConstants.GrantTypes.Ciba},

            // secret for authentication
            ClientSecrets =
            {
                new Secret(GetHash("secret"))
            },

            // scopes that client has access to
            AllowedScopes = { 
                 IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                "api1" }
        },
        // interactive ASP.NET Core MVC client
        new Client
        {
            ClientId = "mvc2",
            ClientSecrets = { new Secret("secret".Sha256()) },
            RequireConsent = true,
            AllowRememberConsent = false,
            ClientName = "The super app",
            ConsentLifetime = 120,
            IdentityTokenLifetime = 120,
            AccessTokenLifetime = 120,
            AbsoluteRefreshTokenLifetime = 3600,
            UserSsoLifetime = 3600,
              FrontChannelLogoutUri = "https://localhost:5003/signout-oidc",
              FrontChannelLogoutSessionRequired = true,
            BackChannelLogoutUri = "https://localhost:5003/signout-oidc",
            BackChannelLogoutSessionRequired = true,

            AllowedGrantTypes = GrantTypes.Code,
            AllowOfflineAccess = true,
            // where to redirect to after login
            RedirectUris = { "https://localhost:5003/signin-oidc" },

            // where to redirect to after logout
            PostLogoutRedirectUris = { "https://localhost:5003/signout-callback-oidc" },

            AllowedScopes = new List<string>
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                "api1"
            }
        }
    };

    public static string GetHash(string str)

    {
        var cs = str.Sha256();
        return cs;
    }
}