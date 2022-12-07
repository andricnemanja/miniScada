using ClientWpfApp.ModbusServiceReference;

namespace ClientWpfApp.Services
{
	public class RtuValueWriter
	{
		private readonly ModbusServiceReference.ModbusDuplexClient modbusDuplexClient;

		public RtuValueWriter(ModbusDuplexClient modbusDuplexClient)
		{
			this.modbusDuplexClient = modbusDuplexClient;
		}

		public void WriteAnalogSignalValue(int rtuId, int signalAddress, int value)
		{
			modbusDuplexClient.WriteAnalogSignal(rtuId, signalAddress, value);
		}

		public void WriteDiscreteSignalValue(int rtuId, int signalAddress, bool value)
		{
			modbusDuplexClient.WriteDiscreteSignal(rtuId, signalAddress, value);
		}

	}
}
