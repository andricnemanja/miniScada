using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using ClientWpfApp.Model.RTU;
using ClientWpfApp.Model.SignalValues;

namespace ClientWpfApp.ModbusCallback
{
	[CallbackBehavior(UseSynchronizationContext = false)]
	public sealed class ModbusServiceCallback : ModbusServiceReference.IModbusDuplexCallback
	{
		private readonly ObservableCollection<RTU> rtuList;

		public ModbusServiceCallback(ObservableCollection<RTU> rtuList)
		{
			this.rtuList = rtuList;
		}

		public void ChangeConnectionStatusToFalse(int rtuId)
		{
			RTU rtu = FindRtu(rtuId);
			rtu.IsConnected = false;
		}

		public async void UpdateAnalogSignalValue(int rtuId, int signalAddress, double signalValue)
		{
			await Task.Run(() =>
			{
				RTU rtu = FindRtu(rtuId);
				AnalogSignalValue analogSignalValue = rtu.AnalogSignalValues.Where(s => s.AnalogSignal.Address == signalAddress).FirstOrDefault();
				analogSignalValue.Value = signalValue;
			});
		}

		public async void UpdateDiscreteSignalValue(int rtuId, int signalAddress, string signalValue)
		{
			await Task.Run(() =>
			{
				RTU rtu = FindRtu(rtuId);
				DiscreteSignalValue discreteSignalValue = rtu.DiscreteSignalValues.Where(s => s.DiscreteSignal.Address == signalAddress).FirstOrDefault();
				discreteSignalValue.State = signalValue;
			});
		}

		private RTU FindRtu(int rtuId)
		{
			return rtuList.Where(r => r.RTUData.ID == rtuId).FirstOrDefault();
		}
	}
}
