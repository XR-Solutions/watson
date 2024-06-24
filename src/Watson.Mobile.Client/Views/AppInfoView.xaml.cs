using Watson.Mobile.Client.ViewModels;

namespace Watson.Mobile.Client.Views
{
    public partial class AppInfoView
    {
        public AppInfoView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            VersionLabel.Text = $"Versie: {VersionTracking.CurrentVersion?.ToString()}";
        }
    }
}
