using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using ClientWpfApp.Model.Signals;

namespace ClientWpfApp.Converters
{
	public class SignalChangeButtonVisibiltyConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			SignalAccessType accessType = (SignalAccessType)value;

			if (accessType == SignalAccessType.Input)
				return Visibility.Hidden;
			return Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
