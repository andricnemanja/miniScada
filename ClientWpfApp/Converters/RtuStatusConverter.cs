using System;
using System.Globalization;
using System.Windows.Data;

namespace ClientWpfApp.Converters
{
	public sealed class RtuStatusConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool offScan = (bool)value;

			if (offScan)
				return "On Scan";
			return "Off Scan";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
