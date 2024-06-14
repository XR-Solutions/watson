using Watson.Mobile.Client.ViewModels;

namespace Watson.Mobile.Client.Views
{
    public partial class SettingsView
    {
        private readonly SettingsViewModel _viewModel;

        public SettingsView(SettingsViewModel viewModel)
        {
            _viewModel = viewModel;
            BindingContext = viewModel;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel.IsInitialized)
            {
                _viewModel.RefreshCommand.Execute(null);
            }
        }
    }
}
