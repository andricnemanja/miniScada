using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Threading.Tasks;
using ClientWpfApp.ModbusCallback;
using ClientWpfApp.ModbusServiceReference;
using ClientWpfApp.Model.RTU;
using ClientWpfApp.Model.SignalValues;

namespace ClientWpfApp.ServiceClients
{
	public sealed class ModbusServiceClient
	{
		private readonly ObservableCollection<RTU> rtuList;
		private ModbusDuplexClient modbusDuplexClient;

		public ModbusServiceClient(ModbusDuplexClient modbusDuplexClient, ObservableCollection<RTU> rtuList)
		{
			this.modbusDuplexClient = modbusDuplexClient;
			this.rtuList = rtuList;
		}

		public ModbusDuplexClient ConnectToModbusService()
		{
			InstanceContext instanceContext = new InstanceContext(new ModbusServiceCallback(rtuList));
			modbusDuplexClient = new ModbusDuplexClient(instanceContext);
			return modbusDuplexClient;
		}

		public void ReadValues()
		{
			Parallel.ForEach(rtuList, rtu =>
			{
				if (rtu.IsConnected)
					ReadSingleRTU(rtu);
			});
		}

		public void WriteAnalogSignalValue(int rtuId, int signalAddress, int value)
		{
			modbusDuplexClient.WriteAnalogSignal(rtuId, signalAddress, value);
		}

		public void WriteDiscreteSignalValue(int rtuId, int signalAddress, bool value)
		{
			modbusDuplexClient.WriteDiscreteSignal(rtuId, signalAddress, value);
		}

		private void ReadSingleRTU(RTU rtu)
		{
			foreach (DiscreteSignalValue signalValue in rtu.DiscreteSignalValues)
			{
				modbusDuplexClient.ReadDiscreteSignal(rtu.RTUData.ID, signalValue.DiscreteSignal.Address);

			}

			foreach (AnalogSignalValue signalValue in rtu.AnalogSignalValues)
			{
				modbusDuplexClient.ReadAnalogSignal(rtu.RTUData.ID, signalValue.AnalogSignal.Address);
			}
		}


	}
}
