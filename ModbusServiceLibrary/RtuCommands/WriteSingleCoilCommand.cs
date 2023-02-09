namespace ModbusServiceLibrary.RtuCommands
{
	public class WriteDiscreteSignalCommand : IRtuCommand
	{
		public int RtuId { get; }
		public int SignalId { get; }
		public string State { get; }

		public WriteDiscreteSignalCommand(int rtuId, int signalId, string state)
		{
			RtuId = rtuId;
			SignalId = signalId;
			State = state;
		}
	}
}
