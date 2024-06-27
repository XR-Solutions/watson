using Watson.Mobile.Client.ViewModels;

namespace Watson.Mobile.Client.Views
{
    public partial class CopilotView
    {
        private readonly CopilotViewModel _viewModel;
        public CopilotView(CopilotViewModel viewModel)
        {
            _viewModel = viewModel;
            BindingContext = viewModel;

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel.IsInitialized) 
                _viewModel.RefreshCommand.Execute(null);
        }
    }
}
