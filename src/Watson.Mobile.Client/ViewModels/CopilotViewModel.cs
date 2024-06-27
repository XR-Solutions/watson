using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Watson.Mobile.Client.Services.Navigation;
using Watson.Mobile.Client.ViewModels.Base;
using Watson.Mobile.Client.Services.Endpoints;

namespace Watson.Mobile.Client.ViewModels
{
    public partial class CopilotViewModel : ViewModelBase
    {
        private readonly ChatService _chatService;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private object chatHistory;

        public CopilotViewModel(INavigationService navigationService, ChatService chatService) : base(navigationService)
        {
            _navigationService = navigationService;
            _chatService = chatService;
        }

        public override async Task InitializeAsync()
        {
            await RefreshAsync();
        }

        [RelayCommand]
        private async Task RefreshAsync()
        {
            if (IsBusy) return;
            await IsBusyFor(
                async () =>
                {
                    var chatHistory = await _chatService.GetChatHistoryAsync();
                });
        }
    }
}
