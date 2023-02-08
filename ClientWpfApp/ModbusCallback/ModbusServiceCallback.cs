using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using ClientWpfApp.Model.RTU;
using ClientWpfApp.Model.SignalValues;
using ModbusServiceLibrary.CommandResult;

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

		public async void UpdateDiscreteSignalValue(object result)
		{
			await Task.Run(() =>
			{
				if(result.GetType() == typeof(ReadSingleCoilResult))
				{
					RTU rtu = FindRtu(((ReadSingleCoilResult)result).RtuId);
					DiscreteSignalValue discreteSignalValue = rtu.DiscreteSignalValues.Where(s => s.DiscreteSignal.Address == ((ReadSingleCoilResult)result).CoilAddress).FirstOrDefault();
					discreteSignalValue.State = ((ReadSingleCoilResult)result).CoilState;
				}
			});
		}

		private RTU FindRtu(int rtuId)
		{
			return rtuList.Where(r => r.RTUData.ID == rtuId).FirstOrDefault();
		}
	}
}
