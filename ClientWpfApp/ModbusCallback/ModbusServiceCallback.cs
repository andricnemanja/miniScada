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

		public async void UpdateAnalogSignalValue(CommandResultBase result)
		{
			await Task.Run(() =>
			{
				if (result.GetType() == typeof(ReadSingleAnalogSignalResult))
				{
					RTU rtu = FindRtu(((ReadSingleAnalogSignalResult)result).RtuId);
					AnalogSignalValue analogSignalValue = rtu.AnalogSignalValues.Where(s => s.AnalogSignal.ID == ((ReadSingleAnalogSignalResult)result).SignalId).FirstOrDefault();
					analogSignalValue.Value = ((ReadSingleAnalogSignalResult)result).SignalValue;
				}
			});
		}

		public async void UpdateDiscreteSignalValue(CommandResultBase result)
		{
			await Task.Run(() =>
			{
				if(result.GetType() == typeof(ReadSingleDiscreteSignalResult))
				{
					RTU rtu = FindRtu(((ReadSingleDiscreteSignalResult)result).RtuId);
					DiscreteSignalValue discreteSignalValue = rtu.DiscreteSignalValues.Where(s => s.DiscreteSignal.ID == ((ReadSingleDiscreteSignalResult)result).SignalId).FirstOrDefault();
					discreteSignalValue.State = ((ReadSingleDiscreteSignalResult)result).State;
				}
			});
		}

		private RTU FindRtu(int rtuId)
		{
			return rtuList.Where(r => r.RTUData.ID == rtuId).FirstOrDefault();
		}
	}
}
