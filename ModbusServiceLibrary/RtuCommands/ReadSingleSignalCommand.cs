namespace ModbusServiceLibrary.RtuCommands
{
	/// <summary>
	/// Command that is sent whenever the signal needs to be read.
	/// </summary>
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
