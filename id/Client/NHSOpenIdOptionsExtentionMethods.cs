using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Duende.IdentityServer;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using NHS.Login.Client;


namespace Microsoft.Extensions.DependencyInjection
{
    public static class NHSOpenIdOptionsExtentionMethods
    {
        public static AuthenticationBuilder AddNhsLoginOpenId(this AuthenticationBuilder authenticationBuilder, NHSLoginSettings settings)
        {
            
            authenticationBuilder.AddOpenIdConnect("NHSLogin", options =>
            {
            
                SetOptions(options, settings);
            });
            return authenticationBuilder;
        }

        public static void SetOptions(OpenIdConnectOptions options, NHSLoginSettings settings)
        {
             options.SignInScheme =IdentityServerConstants.ExternalCookieAuthenticationScheme;
            options.RequireHttpsMetadata = true;
            options.ClientId = settings.ClientId;
            options.Authority = settings.Authority;
            options.ResponseType = "code";
            options.ResponseMode = "form_post";
           //   options.CallbackPath = "/ExternalLogin/Callback";
            options.SaveTokens = true;
         //  options.Scope.Add("openid");
          //  options.Scope.Add("profile");
            //options.Scope.Add("email");

           options.GetClaimsFromUserInfoEndpoint = true;

            options.Scope.Clear();
        options.Scope.Add("openid");
        options.Scope.Add("profile");
      
          options.Scope.Add("profile_extended"); 
     

            options.Events = CreateOpenIdConnectEvents(settings);

           options.ClaimActions.Clear();

                options.ClaimActions.MapUniqueJsonKey("given_name", "given_name");
     
     
        }

        private static OpenIdConnectEvents CreateOpenIdConnectEvents(NHSLoginSettings settings)
        {
            var tokenHelper = new TokenHelper(settings);
            return new OpenIdConnectEvents
            {
                OnRedirectToIdentityProvider = Redirect,
                OnAuthorizationCodeReceived = context => { return AuthorizationCodeReceived(context, tokenHelper); }
                ,OnRedirectToIdentityProviderForSignOut =  context =>
    {
       
        context.Response.Cookies.Delete("idsrv.session", new CookieOptions { Secure = true });
                context.Response.Cookies.Delete(".AspNetCore.Identity.Application", new CookieOptions { Secure = true });
                
                        context.HandleResponse();
                        context.Response.Redirect(context.Properties.RedirectUri);
                        return Task.FromResult(0);

     // context.HttpContext.SignOutAsync("NHSLogin");
  //    return Task.CompletedTask;
   }
                //, OnTokenResponseReceived = context =>
                // {
                //       var handler = new JwtSecurityTokenHandler();

                //     var jsonToken = handler.ReadJwtToken( context.TokenEndpointResponse.IdToken);
                //     var claims = jsonToken.Claims;
                   
                //    // context.Success();
                    
                //     return Task.CompletedTask;
                // },
                
                // OnTokenValidated = context=>
                // {
                //     var p = context.Principal;
                //     return Task.CompletedTask;
                // }
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