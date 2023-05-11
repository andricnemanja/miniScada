namespace ModbusServiceLibrary.RtuCommands
{
	/// <summary>
	/// Command that is sent whenever the new state of the discrete signal is written.
	/// </summary>
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
