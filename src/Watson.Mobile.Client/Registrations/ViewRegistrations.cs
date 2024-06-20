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
            builder.Services.AddTransient<ReportView>();
            builder.Services.AddTransient<AddDeviceView>();
            builder.Services.AddTransient<AddHoloLensView>();
            builder.Services.AddTransient<AddQuest2View>();

            return builder;
        }
    }
}
