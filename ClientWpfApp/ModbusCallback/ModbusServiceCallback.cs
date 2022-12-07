using System.Collections.ObjectModel;
using System.Linq;
using ClientWpfApp.Model.RTU;
using ClientWpfApp.Model.SignalValues;

namespace ClientWpfApp.ModbusCallback
{
	public class ModbusServiceCallback : ModbusServiceReference.IModbusDuplexCallback
	{
		private ObservableCollection<RTU> rtuList = new ObservableCollection<RTU>();

		public ModbusServiceCallback(ObservableCollection<RTU> rtuList)
		{
			this.rtuList = rtuList;
		}
		public void UpdateAnalogSignalValue(int rtuId, int signalAddress, int signalValue)
		{
			RTU rtu = FindRtu(rtuId);
			AnalogSignalValue analogSignalValue = rtu.AnalogSignalValues.Where(s => s.AnalogSignal.Address == signalAddress).FirstOrDefault();
			analogSignalValue.Value = signalValue;
		}

		public void UpdateDiscreteSignalValue(int rtuId, int signalAddress, bool signalValue)
		{
			RTU rtu = FindRtu(rtuId);
			DiscreteSignalValue discreteSignalValue = rtu.DiscreteSignalValues.Where(s => s.DiscreteSignal.Address == signalAddress).FirstOrDefault();
			discreteSignalValue.Value = signalValue;
		}

		private RTU FindRtu(int rtuId)
		{
			return rtuList.Where(r => r.RTUData.ID == rtuId).FirstOrDefault();
		}
	}
}
