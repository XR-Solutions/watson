using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Watson.Mobile.Client.Extensions;

namespace Watson.Mobile.Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Font_Awesome_5_Free-Solid-900.otf", "FontAwesome-Solid");
                    fonts.AddFont("Font_Awesome_5_Free-Regular-400.otf", "FontAwesome-Regular");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.RegisterAppServices()
                .RegisterViews();

            return builder.Build();
        }
    }
}
