using ClientWpfApp.Model.Signals;
using System.ComponentModel;

namespace ClientWpfApp.Model.SignalValues
{
	public class DiscreteSignalValue : INotifyPropertyChanged
	{
		public DiscreteSignal DiscreteSignal { get; set; }
		private bool _value;

		public bool Value
		{
			get { return _value; }
			set 
			{
				if(value != _value)
				{
					_value = value;
					RaisePropertyChanged(nameof(Value));
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