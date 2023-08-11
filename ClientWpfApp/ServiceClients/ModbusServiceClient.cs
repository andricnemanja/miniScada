using System.Threading.Tasks;
using ClientWpfApp.ModbusServiceReference;
using ClientWpfApp.Model;
using ClientWpfApp.Model.RTU;
using ClientWpfApp.Model.SignalValues;

namespace ClientWpfApp.ServiceClients
{
	public sealed class ModbusServiceWpfClient
	{
		private readonly IRtuCache rtuCache;
		private ModbusServiceClient modbusDuplexClient;

		public ModbusServiceWpfClient(ModbusServiceClient modbusDuplexClient, IRtuCache rtuCache)
		{
			this.modbusDuplexClient = modbusDuplexClient;
			this.rtuCache = rtuCache;
		}

		public ModbusServiceClient ConnectToModbusService()
		{
			modbusDuplexClient = new ModbusServiceClient();
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

		public void RtuOnScan(int rtuId)
		{
			modbusDuplexClient.ReceiveCommand(new RtuOnScanCommand()
			{
				RtuId = rtuId
			});
		}

		public void RtuOffScan(int rtuId)
		{
			modbusDuplexClient.ReceiveCommand(new RtuOffScanCommand()
			{
				RtuId = rtuId
			});
		}

		public void WriteAnalogSignalValue(int rtuId, int signalAddress, double value)
		{
			modbusDuplexClient.ReceiveCommand(new WriteAnalogSignalCommand()
			{
				RtuId = rtuId,
				SignalId = signalAddress,
				ValueToWrite = value
			});
		}

		public void WriteDiscreteSignalValue(int rtuId, int signalAddress, string value)
		{
			modbusDuplexClient.ReceiveCommand(new WriteDiscreteSignalCommand()
			{
				RtuId = rtuId,
				SignalId = signalAddress,
				State = value
			});
		}

		private void ReadSingleRTU(RTU rtu)
		{
			foreach (DiscreteSignalValue signalValue in rtu.DiscreteSignalValues)
			{
				modbusDuplexClient.ReceiveCommand(new ReadSingleSignalCommand()
				{
					RtuId = rtu.RTUData.ID,
					SignalId = signalValue.DiscreteSignal.ID
				});
			}
			
			foreach (AnalogSignalValue signalValue in rtu.AnalogSignalValues)
			{
				modbusDuplexClient.ReceiveCommand(new ReadSingleSignalCommand()
				{
					RtuId = rtu.RTUData.ID,
					SignalId = signalValue.AnalogSignal.ID
				});
			}
		}


	}
}
