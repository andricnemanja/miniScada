using System.Runtime.Serialization;

namespace ModbusServiceLibrary.RtuCommands
{
	/// <summary>
	/// Command that is sent whenever the signal needs to be read.
	/// </summary>
	[DataContract]
	public class ReadSingleSignalCommand : RtuCommandBase
	{
		[DataMember]
		public int RtuId { get; set; }

		[DataMember]
		public int SignalId { get; set; }

		public ReadSingleSignalCommand(int rtuId, int signalId)
		{
			RtuId = rtuId;
			SignalId = signalId;
		}
	}
}
