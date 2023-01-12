using System;
using System.Globalization;
using System.Windows.Data;

namespace ClientWpfApp.Converters
{
	internal class DiscreteSignalButtonStatusConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			if ((string)values[0] == (string)values[1])
				return false;
			return true;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
