using System.Runtime.Serialization;

namespace ModbusServiceLibrary.RtuCommands
{
	/// <summary>
	/// Command that is sent whenever the signal needs to be read.
	/// </summary>
	[DataContract]
	public class ReadSingleSignalCommand : IRtuCommand
	{
		[DataMember]
		public int RtuId { get; }

		[DataMember]
		public int SignalId { get;  }

		public ReadSingleSignalCommand(int rtuId, int signalId)
		{
			RtuId = rtuId;
			SignalId = signalId;
		}
	}
}
