using Watson.Mobile.Client.Services.Navigation;

namespace Watson.Mobile.Client
{
    public partial class App : Application
    {
        public App(INavigationService navigationService)
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

            MainPage = new AppShell(navigationService);
        }
    }
}
