using CommunityToolkit.Mvvm.Input;
using Watson.Mobile.Client.Services.Navigation;
using Watson.Mobile.Client.ViewModels.Base;

namespace Watson.Mobile.Client.ViewModels
{
    public partial class CompanionViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public CompanionViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        private async Task AddNewDeviceAsync()
        {
            await _navigationService.NavigateToAsync("///Companion/AddDevice");
        }
    }
}
