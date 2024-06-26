using System.Globalization;

namespace Watson.Mobile.Client.Converters
{
	public class Base64ToImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is string base64String && !string.IsNullOrEmpty(base64String))
			{
				byte[] imageBytes = System.Convert.FromBase64String(base64String);
				return ImageSource.FromStream(() => new MemoryStream(imageBytes));
			}
			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
