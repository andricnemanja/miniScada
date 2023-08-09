using System.Collections.ObjectModel;
using System.ComponentModel;
using ClientWpfApp.Model.SignalValues;
using ClientWpfApp.Util;

namespace ClientWpfApp.Model.RTU
{
	public class RTU : INotifyPropertyChanged
	{
		public RTUData RTUData { get; set; }
		public ObservableCollection<string> Flags { get; set; } = new AsyncObservableCollection<string>();
		public ObservableCollection<AnalogSignalValue> AnalogSignalValues { get; set; }
		public ObservableCollection<DiscreteSignalValue> DiscreteSignalValues { get; set; }

		private bool _isConnected;
		public bool IsConnected
		{
			get { return _isConnected; }
			set
			{
				if (value != _isConnected)
				{
					_isConnected = value;
					RaisePropertyChanged(nameof(IsConnected));
				}
			}
		}

		private bool onScan;
		public bool OnScan
		{
			get { return onScan; }
			set
			{
				if (value != onScan)
				{
					onScan = value;
					RaisePropertyChanged(nameof(OnScan));
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void RaisePropertyChanged(string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
		
	}
}
