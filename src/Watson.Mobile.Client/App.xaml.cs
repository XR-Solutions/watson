using Watson.Mobile.Client.Services.Navigation;
using Watson.Mobile.Client.Services.Settings;

namespace Watson.Mobile.Client
{
    public partial class App : Application
    {
        public App(INavigationService navigationService, ISettingsService settingsService)
        {
            // We will not use the webview for anything else but the model viewer, otherwise this will be quite unsafe.
            // This will give us access to local files, such as our 3d models.
            Microsoft.Maui.Handlers.WebViewHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.Settings.JavaScriptEnabled = true;
                handler.PlatformView.Settings.AllowFileAccess = true;
                handler.PlatformView.Settings.AllowFileAccessFromFileURLs = true;
                handler.PlatformView.Settings.AllowUniversalAccessFromFileURLs = true;
#endif
            });

            InitializeComponent();
            settingsService.Initialize();

            MainPage = new AppShell(navigationService, settingsService);
        }
    }
}
