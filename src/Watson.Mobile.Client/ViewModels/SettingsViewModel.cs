using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Watson.Mobile.Client.Services.Identity;
using Watson.Mobile.Client.Services.Navigation;
using Watson.Mobile.Client.ViewModels.Base;
using Watson.Mobile.Client.Models.User;

namespace Watson.Mobile.Client.ViewModels
{
    public partial class SettingsViewModel : ViewModelBase
    {
        private readonly IIdentityService _identityService;

        [ObservableProperty]
        private UserInfo? user;

        [ObservableProperty]
        private bool isLoggedIn = false;

        public SettingsViewModel(INavigationService navigationService, IIdentityService identityService) : base(navigationService)
        {
            _identityService = identityService;
        }

        public override async Task InitializeAsync()
        {
            await RefreshAsync();
        }

        [RelayCommand]
        private async Task LogOutAsync()
        {
            await _identityService.LogoutAsync();
            await RefreshAsync();
        }

        [RelayCommand]
        private async Task LoginAsync()
        {
            await _identityService.LoginAsync();
            await RefreshAsync();
        }

        [RelayCommand]
        private async Task RefreshAsync()
        {
            if (IsBusy) return;
            await IsBusyFor(
                async () =>
                {
                    var user = await _identityService.GetUserInfoAsync();
                    IsLoggedIn = user != null;
                    User = user;
                });
        }
    }
}
