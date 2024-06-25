using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Watson.Mobile.Client.Services.Navigation;
using Watson.Mobile.Client.Services.Settings;
using Watson.Mobile.Client.ViewModels.Base;

namespace Watson.Mobile.Client.ViewModels
{
    public partial class AppearanceViewModel : ViewModelBase
    {
        private readonly ISettingsService _settingsService;

        [ObservableProperty]
        private string currentTheme;

        [ObservableProperty]
        public bool darkBorder = false;

        [ObservableProperty]
        public bool lightBorder = false;

        [ObservableProperty]
        public bool autoBorder = false;

        public AppearanceViewModel(INavigationService navigationService, ISettingsService settingsService) : base(navigationService) 
        {
            _settingsService = settingsService;
            CurrentTheme = _settingsService.PreferedAppTheme;
            SwitchSelectedBorder();

            Application.Current.RequestedThemeChanged += (s, a) =>
            {
                CurrentTheme = _settingsService.PreferedAppTheme;
                SwitchSelectedBorder();
            };
        }

        [RelayCommand]
        public void ChangeTheme(string newTheme)
        {
            CurrentTheme = newTheme;
            SwitchSelectedBorder();
            _settingsService.PreferedAppTheme = newTheme;
        }

        private void SwitchSelectedBorder()
        {
            DarkBorder = CurrentTheme == "dark";
            LightBorder = CurrentTheme == "light";
            AutoBorder = CurrentTheme == "auto";
        }
    }
}
