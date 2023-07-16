using System.ServiceModel;
using System.Threading.Tasks;
using ClientWpfApp.ModbusCallback;
using ClientWpfApp.ModbusServiceReference;
using ClientWpfApp.Model;
using ClientWpfApp.Model.RTU;
using ClientWpfApp.Model.SignalValues;

namespace ClientWpfApp.ServiceClients
{
	public sealed class ModbusServiceClient
	{
		private readonly IRtuCache rtuCache;
		private ModbusDuplexClient modbusDuplexClient;

		public ModbusServiceClient(ModbusDuplexClient modbusDuplexClient, IRtuCache rtuCache)
		{
			this.modbusDuplexClient = modbusDuplexClient;
			this.rtuCache = rtuCache;
		}

		public ModbusDuplexClient ConnectToModbusService()
		{
			ICommandResultReceiver commandResultReceiver = new CommandResultReceiver(rtuCache);
			CommandResultQueue commandResultQueue = new CommandResultQueue(commandResultReceiver);
			ModbusServiceCallback modbusServiceCallback = new ModbusServiceCallback(commandResultQueue);
			InstanceContext instanceContext = new InstanceContext(modbusServiceCallback);
			modbusDuplexClient = new ModbusDuplexClient(instanceContext);
			return modbusDuplexClient;
		}

		public void ReadValues()
		{
			Parallel.ForEach(rtuCache.RtuList, rtu =>
			{
				if (rtu.IsConnected)
					ReadSingleRTU(rtu);
			});
			/*
			Task.Run(() =>
			{
				while (true)
				{
					Parallel.ForEach(rtuCache.RtuList, rtu =>
					{
						if (rtu.IsConnected)
							ReadSingleRTU(rtu);
					});
					Thread.Sleep(1000);
				}
			});*/
		}

		public void WriteAnalogSignalValue(int rtuId, int signalAddress, double value)
		{
			modbusDuplexClient.WriteAnalogSignal(rtuId, signalAddress, value);
		}

		public void WriteDiscreteSignalValue(int rtuId, int signalAddress, string value)
		{
			modbusDuplexClient.WriteDiscreteSignal(rtuId, signalAddress, value);
		}

		private void ReadSingleRTU(RTU rtu)
		{
			foreach (DiscreteSignalValue signalValue in rtu.DiscreteSignalValues)
			{
				modbusDuplexClient.ReadDiscreteSignal(rtu.RTUData.ID, signalValue.DiscreteSignal.ID);
			}
			
			foreach (AnalogSignalValue signalValue in rtu.AnalogSignalValues)
			{
				modbusDuplexClient.ReadAnalogSignal(rtu.RTUData.ID, signalValue.AnalogSignal.ID);
			}
		}


	}
}
