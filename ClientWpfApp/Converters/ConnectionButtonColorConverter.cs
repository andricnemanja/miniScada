using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;

namespace ClientWpfApp.Converters
{
	public sealed class ConnectionButtonColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			ObservableCollection<string> flags = (ObservableCollection<string>)value;

			if (flags.Contains("Active Connection"))
			{
				return "Green";
			}

			return "Red";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
