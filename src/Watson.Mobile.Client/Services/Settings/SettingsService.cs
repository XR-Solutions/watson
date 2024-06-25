namespace Watson.Mobile.Client.Services.Settings
{
    public class SettingsService : ISettingsService
    {
        private const string IdAppTheme = "prefered_theme";

        public void Initialize()
        {
            PreferedAppTheme = Preferences.Get(IdAppTheme, "auto");
        }

        public string PreferedAppTheme { 
            get => Preferences.Get(IdAppTheme, "auto"); 
            set 
            {
                Preferences.Set(IdAppTheme, value);

                switch (value)
                {
                    case "dark": Application.Current.UserAppTheme = AppTheme.Dark; break;
                    case "light": Application.Current.UserAppTheme = AppTheme.Light; break;
                    default: Application.Current.UserAppTheme = AppTheme.Unspecified; break;
                }
            }
        }
    }
}
