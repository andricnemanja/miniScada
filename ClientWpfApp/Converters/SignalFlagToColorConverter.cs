using System;
using System.Globalization;
using System.Windows.Data;
using ClientWpfApp.Model.Flags;

namespace ClientWpfApp.Converters
{
	public sealed class SignalFlagToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			FlagType flagType = (FlagType)value;

			switch (flagType)
			{
				case FlagType.Info: return "DarkGray";
				case FlagType.Warn: return "Yellow";
				case FlagType.Error: return "Orange";
				case FlagType.Fatal: return "Red";
				default: return "";
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
