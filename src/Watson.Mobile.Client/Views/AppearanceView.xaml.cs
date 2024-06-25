using Watson.Mobile.Client.ViewModels;

namespace Watson.Mobile.Client.Views
{
    public partial class AppearanceView
    {
        public AppearanceView(AppearanceViewModel viewModel)
        {
            BindingContext = viewModel;

            InitializeComponent();
        }
    }
}
