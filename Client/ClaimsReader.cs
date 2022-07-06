using System.Collections.Generic;
using System.Net.Http;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace NHS.Login.Client
{
    public class ClaimsReader
    {
        IHttpContextAccessor _accessor;
        NHSLoginSettings _settings;
        IHttpClientFactory _clientFactory;
        public ClaimsReader(
            IHttpClientFactory clientFactory,
            IHttpContextAccessor accessor,
            IOptions<NHSLoginSettings> settings)
        {
            _clientFactory = clientFactory;
            _settings = settings.Value;
            _accessor = accessor;
        }
        public async IAsyncEnumerable<Claim> GetClaimsAsync()
        {
            var idtoken = await GetIdTokenAsync();
            var accessToken = await GetTokenAsync();
            var response = await GetUserInfoAsync(accessToken);
            foreach (var claim in response.Claims)
                yield return claim;
        }

        private async Task<string> GetTokenAsync()
        {
            return await _accessor.HttpContext.GetTokenAsync("access_token");
        }
                private async Task<string> GetIdTokenAsync()
        {
            return await _accessor.HttpContext.GetTokenAsync("id_token");
        }


        private async Task<UserInfoResponse> GetUserInfoAsync(string accessToken)
        {
            var client = _clientFactory.CreateClient();
            var disco = await client.GetDiscoveryDocumentAsync(_settings.Authority);
            return await client.GetUserInfoAsync(new UserInfoRequest
            {
                Address = _settings.Authority + "userinfo",
                Token = accessToken
            });
        }
    }
}
