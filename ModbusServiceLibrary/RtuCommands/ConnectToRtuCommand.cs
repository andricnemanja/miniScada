namespace ModbusServiceLibrary.RtuCommands
{
	/// <summary>
	/// Command that is sent whenever we need to establish the connection with the RTU.
	/// </summary>
	public class ConnectToRtuCommand : IRtuCommand
	{
		public int RtuId { get; set; }

		public ConnectToRtuCommand(int rtuId)
		{
			RtuId = rtuId;
		}
	}
}
