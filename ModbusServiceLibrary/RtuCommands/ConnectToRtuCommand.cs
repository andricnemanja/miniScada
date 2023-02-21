namespace ModbusServiceLibrary.RtuCommands
{
	public class ReadSingleSignalCommandResult : IRtuCommand
	{
		public int RtuId { get; set; }

		public ReadSingleSignalCommandResult(int rtuId)
		{
			RtuId = rtuId;
		}
	}
}
