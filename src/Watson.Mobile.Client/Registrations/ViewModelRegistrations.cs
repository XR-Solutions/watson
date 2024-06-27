using Watson.Mobile.Client.ViewModels;

namespace Watson.Mobile.Client.Extensions
{
    public static class ViewModelRegistrations
    {
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<SettingsViewModel>();
            builder.Services.AddSingleton<CompanionViewModel>();
            builder.Services.AddSingleton<AppearanceViewModel>();
            builder.Services.AddSingleton<CopilotViewModel>();

            return builder;
        }
    }
}
