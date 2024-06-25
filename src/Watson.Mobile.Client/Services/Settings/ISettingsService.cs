namespace Watson.Mobile.Client.Services.Settings
{
    public interface ISettingsService
    {
        string PreferedAppTheme { get; set; }

        public void Initialize();
    }
}
