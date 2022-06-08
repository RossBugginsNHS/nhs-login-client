using System.Collections.Generic;
using System.Net.Http;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.Extensions.Options;

namespace NHS.Login.Client
{
    public class ClaimsReader
    {
        IHttpContextAccessor _accessor;
        NHSLoginSettings _settings;
        public ClaimsReader(IHttpContextAccessor accessor, IOptions<NHSLoginSettings> settings)
        {
            _settings = settings.Value;
            _accessor = accessor;
        }
        public async IAsyncEnumerable<Claim> GetAsync()
        {
            var accessToken = await _accessor.HttpContext.GetTokenAsync("access_token");

            var client = new HttpClient();

            var disco = await client.GetDiscoveryDocumentAsync(_settings.Authority);

            var response = await client.GetUserInfoAsync(new UserInfoRequest
            {
                Address = _settings.Authority + "userinfo",
                Token = accessToken
            });

            foreach (var claim in response.Claims)
                yield return claim;
        }
    }
}
