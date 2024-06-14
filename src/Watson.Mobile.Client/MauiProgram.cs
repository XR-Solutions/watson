using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Watson.Mobile.Client.Extensions;
using Watson.Mobile.Client.Registrations;

namespace Watson.Mobile.Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"Watson.Mobile.Client.appsettings.json");
            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Font_Awesome_5_Free-Solid-900.otf", "FontAwesome-Solid");
                    fonts.AddFont("Font_Awesome_5_Free-Regular-400.otf", "FontAwesome-Regular");
                })
                .Configuration.AddConfiguration(config);

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.RegisterAppServices()
                .RegisterIdentity(config)
                .RegisterViewModels()
                .RegisterViews();

            return builder.Build();
        }
    }
}
