using Watson.Mobile.Client.ViewModels;

namespace Watson.Mobile.Client.Views
{
    public partial class CompanionView
    {
        private readonly CompanionViewModel _viewModel;
        public CompanionView(CompanionViewModel viewModel)
        {
            _viewModel = viewModel;
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}
