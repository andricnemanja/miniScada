using ClientWpfApp.Model.SignalValues;
using ClientWpfApp.Model;
using System.Collections.ObjectModel;

namespace ClientWpfApp.Model.RTU
{
    public class RTU
    {
		public RTUData RTUData { get; set; }
		public bool IsConnected { get; set; }
		public ObservableCollection<AnalogSignalValue> AnalogSignalValues { get; set; }
		public ObservableCollection<DiscreteSignalValue> DiscreteSignalValues { get; set; }

	}
}
