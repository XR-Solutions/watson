using Watson.Mobile.Client.Services.Endpoints;
using Watson.Mobile.Client.Services.Navigation;
using Watson.Mobile.Client.Services.Settings;

namespace Watson.Mobile.Client.Extensions
{
    public static class AppServicesRegistrations
    {
        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<INavigationService, MauiNavigationService>();
            builder.Services.AddSingleton<ISettingsService, SettingsService>();
            builder.Services.AddSingleton<ChatService>();

            return builder;
        }
    }
}
