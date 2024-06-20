using Watson.Mobile.Client.Services.Navigation;

namespace Watson.Mobile.Client.Views
{
    public partial class AddDeviceView
    {
        private readonly INavigationService _navigationService;
        public AddDeviceView(INavigationService navigationService)
        {
            _navigationService = navigationService;
            InitializeComponent();
        }

        public void AddHoloLensTwo(object sender, EventArgs e)
        {
            _navigationService.NavigateToAsync("///Companion/AddDevice/HoloLens2");
        }

        public void AddMetaQuestTwo(object sender, EventArgs e)
        {
            _navigationService.NavigateToAsync("///Companion/AddDevice/Quest2");
        }
    }
}
