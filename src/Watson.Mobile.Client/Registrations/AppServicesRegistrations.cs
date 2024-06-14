using Watson.Mobile.Client.Services.Navigation;

namespace Watson.Mobile.Client.Extensions
{
    public static class AppServicesRegistrations
    {
        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<INavigationService, MauiNavigationService>();

            return builder;
        }
    }
}
