namespace ModbusServiceLibrary.RtuCommands
{
	public class ReadSingleSignalCommand : IRtuCommand
	{
		public int RtuId { get; }
		public int SignalId { get;  }

		public ReadSingleSignalCommand(int rtuId, int signalId)
		{
			RtuId = rtuId;
			SignalId = signalId;
		}
	}
}
