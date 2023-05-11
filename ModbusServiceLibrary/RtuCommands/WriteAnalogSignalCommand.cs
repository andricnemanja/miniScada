namespace ModbusServiceLibrary.RtuCommands
{
	/// <summary>
	/// Command that is sent whenever the new state of the analog signal is written.
	/// </summary>
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
