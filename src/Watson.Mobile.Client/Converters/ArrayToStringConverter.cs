using System.Globalization;

namespace Watson.Mobile.Client.Converters
{
	public class ArrayToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is float[] array && array.Length > 0)
			{
				return string.Join(", ", array.Select(v => v.ToString("F2")));
			}

			return "N/A";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
