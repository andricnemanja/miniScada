namespace ClientWpfApp.ServiceClients
{
	public sealed class RtuConnection
	{
		private readonly ModbusServiceWpfClient modbusServiceClient;

		public RtuConnection(ModbusServiceWpfClient modbusServiceClient)
		{
			this.modbusServiceClient = modbusServiceClient;
		}

		public void RtuOnScan(int rtuId)
		{
			modbusServiceClient.RtuOnScan(rtuId);
		}
	}
}
