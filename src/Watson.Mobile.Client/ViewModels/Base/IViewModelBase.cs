using CommunityToolkit.Mvvm.Input;
using Watson.Mobile.Client.Services.Navigation;

namespace Watson.Mobile.Client.ViewModels.Base
{
    public interface IViewModelBase : IQueryAttributable
    {
        public INavigationService NavigationService { get; }
        public IAsyncRelayCommand InitializeAsyncCommand { get; }
        public bool IsBusy { get; }
        public bool IsInitialized { get; }
        Task InitializeAsync();
    }
}
