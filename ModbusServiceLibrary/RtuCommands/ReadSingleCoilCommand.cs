namespace ModbusServiceLibrary.RtuCommands
{
	public class ReadSingleCoilCommand : IRtuCommand
	{
		public int RtuId { get; }
		public int SignalId { get;  }

		public ReadSingleCoilCommand(int rtuId, int signalId)
		{
			RtuId = rtuId;
			SignalId = signalId;
		}
	}
}
