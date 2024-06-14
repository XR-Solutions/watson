using System.Security.Claims;
using Watson.Mobile.Client.Models.User;

namespace Watson.Mobile.Client.Services.Identity
{
    public interface IIdentityService
    {
        public Task<ClaimsPrincipal> LoginAsync();
        public Task LogoutAsync();
        public Task<UserInfo?> GetUserInfoAsync();
        public bool IsSignedIn();
        public Task<string?> GetIdentityTokenAsync();
    }
}
