using ClientWpfApp.ModbusServiceReference;
using ModbusServiceLibrary.CommandResult;

namespace ClientWpfApp.ServiceClients
{
	public sealed class RtuConnection
	{
		private readonly ModbusDuplexClient modbusDuplexClient;

		public RtuConnection(ModbusDuplexClient modbusDuplexClient)
		{
			this.modbusDuplexClient = modbusDuplexClient;
		}

		public ConnectToRtuResult TryConnectToRtu(int rtuId)
		{
			return modbusDuplexClient.ConnectToRtu(rtuId);
		}
	}
}
