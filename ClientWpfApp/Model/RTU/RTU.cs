using System.Collections.ObjectModel;
using System.ComponentModel;
using ClientWpfApp.Model.Flags;
using ClientWpfApp.Model.SignalValues;
using ClientWpfApp.Util;

namespace ClientWpfApp.Model.RTU
{
	public class RTU : INotifyPropertyChanged
	{
		public RTUData RTUData { get; set; }
		public ObservableCollection<Flag> Flags { get; set; } = new AsyncObservableCollection<Flag>();
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

		private bool offScan = false;
		public bool OffScan
		{
			get { return offScan; }
			set
			{
				if (value != offScan)
				{
					offScan = value;
					RaisePropertyChanged(nameof(OffScan));
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void RaisePropertyChanged(string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
		
	}
}
