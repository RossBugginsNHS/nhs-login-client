using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using NHS.Login.Client;


namespace Microsoft.Extensions.DependencyInjection
{
    public static class NHSOpenIdOptionsExtentionMethods
    {
        public static AuthenticationBuilder AddNhsLoginOpenId(this AuthenticationBuilder authenticationBuilder, NHSLoginSettings settings)
        {
            authenticationBuilder.AddOpenIdConnect(options =>
            {
                SetOptions(options, settings);
            });
            return authenticationBuilder;
        }

        public static void SetOptions(OpenIdConnectOptions options, NHSLoginSettings settings)
        {
            options.RequireHttpsMetadata = true;
            options.ClientId = settings.ClientId;
            options.Authority = settings.Authority;
            options.ResponseType = "code";
            options.ResponseMode = "form_post";
            //  options.CallbackPath = "/Home";
            options.SaveTokens = true;
            options.Events = CreateOpenIdConnectEvents(settings);
        }

        private static OpenIdConnectEvents CreateOpenIdConnectEvents(NHSLoginSettings settings)
        {
            var tokenHelper = new TokenHelper(settings);
            return new OpenIdConnectEvents
            {
                OnRedirectToIdentityProvider = Redirect,
                OnAuthorizationCodeReceived = context => { return AuthorizationCodeReceived(context, tokenHelper); }
            };
        }

        private static Task Redirect(RedirectContext context)
        {
            if (context.ProtocolMessage.RequestType == OpenIdConnectRequestType.Authentication)
                context.ProtocolMessage.Parameters.Add("vtr", "[\"P0.Cp.Cd\", \"P0.Cp.Ck\", \"P0.Cm\"]");
            return Task.CompletedTask;
        }

        private static Task AuthorizationCodeReceived(AuthorizationCodeReceivedContext context, TokenHelper tokenHelper)
        {
            if (context.TokenEndpointRequest?.GrantType == OpenIdConnectGrantTypes.AuthorizationCode)
            {
                context.TokenEndpointRequest.ClientAssertionType = "urn:ietf:params:oauth:client-assertion-type:jwt-bearer";
                context.TokenEndpointRequest.ClientAssertion = tokenHelper.CreateClientAuthJwt();
            }
            return Task.CompletedTask;
        }
    }

}