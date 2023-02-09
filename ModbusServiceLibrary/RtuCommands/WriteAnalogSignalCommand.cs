namespace ModbusServiceLibrary.RtuCommands
{
	public sealed class WriteAnalogSignalCommand : IRtuCommand
	{
		public int RtuId { get; }
		public int SignalId { get; }
		public double ValueToWrite { get; }

		public WriteAnalogSignalCommand(int rtuId, int signalId, double valueToWrite)
		{
			RtuId = rtuId;
			SignalId = signalId;
			ValueToWrite = valueToWrite;
		}
	}
}
