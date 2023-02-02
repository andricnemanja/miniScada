namespace ModbusServiceLibrary.RtuCommands
{
	public class ConnectToRtuCommand : IRtuCommand
	{
		public int RtuId { get; set; }
		public string IpAddress { get; set; }
		public int Port { get; set; }

		public ConnectToRtuCommand(int rtuId, string ipAddress, int port)
		{
			RtuId = rtuId;
			IpAddress = ipAddress;
			Port = port;
		}
	}
}
