using ClientWpfApp.ModbusServiceReference;

namespace ClientWpfApp.ServiceReader
{
	public class RtuConnection
	{
		private readonly ModbusServiceReference.ModbusDuplexClient modbusDuplexClient;

		public RtuConnection(ModbusDuplexClient modbusDuplexClient)
		{
			this.modbusDuplexClient = modbusDuplexClient;
		}

		public bool TryConnectToRtu(int rtuId)
		{
			return modbusDuplexClient.TryConnectToRtu(rtuId);
		}
	}
}
