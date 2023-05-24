using System.Runtime.Serialization;

namespace ModbusServiceLibrary.RtuCommands
{
	/// <summary>
	/// Command that is sent whenever the new state of the discrete signal is written.
	/// </summary>
	[DataContract]
	public class WriteDiscreteSignalCommand : RtuCommandBase
	{
		[DataMember]
		public int RtuId { get; set; }
		
		[DataMember]
		public int SignalId { get; set; }
		
		[DataMember]
		public string State { get; set; }

		public WriteDiscreteSignalCommand(int rtuId, int signalId, string state)
		{
			RtuId = rtuId;
			SignalId = signalId;
			State = state;
		}
	}
}
