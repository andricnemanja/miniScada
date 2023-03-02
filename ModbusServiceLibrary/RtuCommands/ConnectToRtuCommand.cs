namespace ModbusServiceLibrary.RtuCommands
{
	public class ConnectToRtuCommand : IRtuCommand
	{
		public int RtuId { get; set; }

		public ConnectToRtuCommand(int rtuId)
		{
			RtuId = rtuId;
		}
	}
}
