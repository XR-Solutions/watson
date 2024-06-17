using Watson.Mobile.Client.Services.Navigation;

namespace Watson.Mobile.Client
{
    public partial class App : Application
    {
        public App(INavigationService navigationService)
        {
            InitializeComponent();

            MainPage = new AppShell(navigationService);
        }
    }
}
