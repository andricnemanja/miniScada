using System;
using System.Globalization;
using System.Windows.Data;

namespace ClientWpfApp.Converters
{
	public sealed class ConnectionButtonColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool connectionStatus = (bool)value;

			if (connectionStatus)
				return "Green";

			return "Red";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
