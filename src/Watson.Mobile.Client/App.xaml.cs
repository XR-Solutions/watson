using Watson.Mobile.Client.Views;

namespace Watson.Mobile.Client
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new AppFlyout();
		}
	}
}
