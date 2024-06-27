using Watson.Mobile.Client.Views;

namespace Watson.Mobile.Client.Extensions
{
    public static class ViewRegistrations
    {
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<CompanionView>();
            builder.Services.AddTransient<SettingsView>();
            builder.Services.AddTransient<CopilotView>();
            builder.Services.AddTransient<AppInfoView>();
            builder.Services.AddTransient<AppearanceView>();
            builder.Services.AddTransient<AddDeviceView>();
            builder.Services.AddTransient<AddHoloLensView>();
            builder.Services.AddTransient<AddQuest2View>();
            builder.Services.AddTransient<NotesView>();
            builder.Services.AddTransient<NotesPage>();

            return builder;
        }
    }
}
