using System.ComponentModel;
using ClientWpfApp.Model.Signals;

namespace ClientWpfApp.Model.SignalValues
{
	public class DiscreteSignalValue : INotifyPropertyChanged
	{
		public DiscreteSignal DiscreteSignal { get; set; }

		private string _state;
		public string State
		{
			get { return _state; }
			set
			{
				if (value != _state)
				{
					_state = value;
					RaisePropertyChanged(nameof(State));
				}
			}
		}

		private string[] _possibleStates;

		public string[] PossibleStates
		{
			get { return _possibleStates; }
			set {
				if (value != _possibleStates)
				{
					_possibleStates = value;
					RaisePropertyChanged(nameof(PossibleStates));
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