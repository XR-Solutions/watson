using Watson.Mobile.Client.Services.Navigation;
using Watson.Mobile.Client.Services.Settings;
using Watson.Mobile.Client.Views;

namespace Watson.Mobile.Client
{
    public partial class AppShell : Shell
    {
        private readonly INavigationService _navigationService;
        private readonly ISettingsService _settingsService;

        public AppShell(INavigationService navigationService, ISettingsService settingsService)
        {
            _navigationService = navigationService;
            _settingsService = settingsService;

            InitializeComponent();
            InitializeRouting();
        }

        protected override async void OnHandlerChanged()
        {
            base.OnHandlerChanged();

            if (Handler is not null)
            {
                await _navigationService.InitializeAsync();
            }
        }

        private static void InitializeRouting()
        {
            Routing.RegisterRoute("AppInfo", typeof(AppInfoView));
            Routing.RegisterRoute("Appearance", typeof(AppearanceView));

            Routing.RegisterRoute("Companion/AddDevice", typeof(AddDeviceView));
            Routing.RegisterRoute("Companion/AddDevice/HoloLens2", typeof(AddHoloLensView));
            Routing.RegisterRoute("Companion/AddDevice/Quest2", typeof(AddQuest2View));
        }
    }
}
