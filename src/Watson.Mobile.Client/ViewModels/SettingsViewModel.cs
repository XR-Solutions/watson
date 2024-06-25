using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Watson.Mobile.Client.Services.Identity;
using Watson.Mobile.Client.Services.Navigation;
using Watson.Mobile.Client.ViewModels.Base;
using Watson.Mobile.Client.Models.User;
using Microsoft.Extensions.Options;
using Watson.Mobile.Client.Options;

namespace Watson.Mobile.Client.ViewModels
{
    public partial class SettingsViewModel : ViewModelBase
    {
        private readonly IIdentityService _identityService;
        private readonly INavigationService _navigationService;
        private readonly LinkSettings _links;

        [ObservableProperty]
        private UserInfo? user;

        [ObservableProperty]
        private bool isLoggedIn = false;

        [ObservableProperty]
        private string currentVersion = VersionTracking.CurrentVersion.ToString();

        public SettingsViewModel(INavigationService navigationService, IIdentityService identityService, IOptions<LinkSettings> linkOption) : base(navigationService)
        {
            _navigationService = navigationService;
            _identityService = identityService;
            _links = linkOption.Value;
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
        private void OpenHelpSite() => OpenUrlInDefaultWebsite(_links.HelpSiteUrl);

        [RelayCommand]
        private void OpenGithubSite() => OpenUrlInDefaultWebsite(_links.GitHubRepoUrl);

        [RelayCommand]
        private async Task OpenAppearanceAsync() => await _navigationService.NavigateToAsync("Appearance");

        [RelayCommand]
        private async Task OpenAppInfoAsync() => await _navigationService.NavigateToAsync("AppInfo");

        private static void OpenUrlInDefaultWebsite(string link)
        {
            var uri = new Uri(link);
            Browser.Default.OpenAsync(uri, BrowserLaunchMode.External);
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
