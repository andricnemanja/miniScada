using System.ComponentModel;
using ClientWpfApp.Model.Signals;

namespace ClientWpfApp.Model.SignalValues
{
	public class AnalogSignalValue : INotifyPropertyChanged
	{
		public AnalogSignal AnalogSignal { get; set; }
		private int _value;

		public int Value
		{
			get { return _value; }
			set
			{
				if (value != _value)
				{
					_value = value;
					RaisePropertyChanged(nameof(Value));
				}
			}
		}

		private string _unit = "";

		public string Unit
		{
			get { return _unit; }
			set 
			{
				if (value != _unit)
				{
					_unit = value;
					RaisePropertyChanged(nameof(Unit));
				}
			}
		}


		public event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged(string property)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(property));
			}
		}
	}
}