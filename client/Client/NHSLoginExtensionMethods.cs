using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NHS.Login.Client;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class NHSLoginExtensionMethods
    {
        public static WebApplicationBuilder AddNHSLogin(this WebApplicationBuilder builder )
        {
            builder.Services.AddHttpClient();
            builder.Services.Configure<NHSLoginSettings>(builder.Configuration.GetSection(NHSLoginSettings.Name));
            builder.Services.AddTransient<ClaimsReader>();
            var conf = new NHSLoginSettings();
            builder.Configuration.Bind(NHSLoginSettings.Name, conf);

            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddNhsLoginOpenId(conf);
            return builder;
        }
    }
}