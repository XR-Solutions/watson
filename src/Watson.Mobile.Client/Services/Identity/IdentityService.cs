using Auth0.OidcClient;
using System.Security.Claims;
using Watson.Mobile.Client.Models.User;

namespace Watson.Mobile.Client.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly Auth0Client _client;
        private readonly string IdentityStorageKey = "IdentityToken";
        private readonly string AccessStorageKey = "AccessToken";

        public IdentityService(Auth0Client client)
        {
            _client = client;
        }

        public async Task<UserInfo?> GetUserInfoAsync()
        {
            var token = await GetAccessTokenAsync();
            if (token == null) return null;

            var userInfo = await _client.GetUserInfoAsync(token);
            var claims = userInfo.Claims;

            return new UserInfo()
            {
                Name = claims.Where(c => c.Type == "name").FirstOrDefault()?.Value ?? "",
                Email = claims.Where(c => c.Type == "email").FirstOrDefault()?.Value ?? "",
                ImageUrl = claims.Where(c => c.Type == "picture").FirstOrDefault()?.Value ?? ""
            };
        }

        public async Task<ClaimsPrincipal> LoginAsync()
        {
            var loginResult = await _client.LoginAsync();
            await SecureStorage.SetAsync(IdentityStorageKey, loginResult.IdentityToken);
            await SecureStorage.SetAsync(AccessStorageKey, loginResult.AccessToken);
            return loginResult.User;
        }

        public async Task LogoutAsync()
        {
            await _client.LogoutAsync();
            SecureStorage.Remove(IdentityStorageKey);
            SecureStorage.Remove(AccessStorageKey);
        }
        
        public bool IsSignedIn()
        {
            return SecureStorage.GetAsync(IdentityStorageKey).Result != null;
        }

        public async Task<string?> GetIdentityTokenAsync() => 
            await SecureStorage.GetAsync(IdentityStorageKey);

        public async Task<string?> GetAccessTokenAsync() =>
            await SecureStorage.GetAsync(AccessStorageKey);

    }
}
