using Auth0.OidcClient;
using Microsoft.Extensions.Configuration;
using Watson.Mobile.Client.Options;
using Watson.Mobile.Client.Services.Identity;

namespace Watson.Mobile.Client.Registrations
{
    public static class IdentityRegistration
    {
        public static MauiAppBuilder RegisterIdentity(this MauiAppBuilder builder, IConfiguration configuration)
        {
            var auth0Settings = new Auth0Settings();
            configuration.Bind(nameof(auth0Settings), auth0Settings);

            var authClient = new Auth0Client(new Auth0ClientOptions
            {
                Domain = auth0Settings.Domain,
                ClientId = auth0Settings.ClientId,
                RedirectUri = "watsonmc://callback",
                PostLogoutRedirectUri = "watsonmc://callback",
                Scope = auth0Settings.Scope
            });

            builder.Services.AddSingleton(authClient);
            builder.Services.AddSingleton<IIdentityService, IdentityService>();

            return builder;
        }
    }
}
