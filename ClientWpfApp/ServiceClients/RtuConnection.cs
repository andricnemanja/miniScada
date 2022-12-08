using ClientWpfApp.ModbusServiceReference;

namespace ClientWpfApp.ServiceClients
{
	public sealed class RtuConnection
	{
		private readonly ModbusDuplexClient modbusDuplexClient;

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
