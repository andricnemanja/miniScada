using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using ClientWpfApp.Model.Flags;

namespace ClientWpfApp.Converters
{
	public sealed class SignalFlagToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			ObservableCollection<Flag> flags = (ObservableCollection<Flag>)value;

			int maxFlagLevel = 0;

			foreach(var flag in flags)
			{
				if((int)flag.Type > maxFlagLevel)
				{
					maxFlagLevel = (int)flag.Type;
				}
			}

			switch (maxFlagLevel)
			{
				case 0: return "Transparent";
				case 1: return "LightGray";
				case 2: return "Yellow";
				case 3: return "Red";
				default: return "";
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
