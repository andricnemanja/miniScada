using System.Runtime.Serialization;

namespace ModbusServiceLibrary.CommandResult
{
	[DataContract]
	public class ReadSingleDiscreteSignalResult : CommandResultBase
	{
		[DataMember]
		public CommandStatus CommandStatus { get; set; }
		[DataMember]
		public int SignalId { get; set; }
		[DataMember]
		public string State { get; set; }

		public ReadSingleDiscreteSignalResult(int rtuId, CommandStatus commandStatus, int signalId, string state) : base(rtuId)
		{
			CommandStatus = commandStatus;
			SignalId = signalId;
			State = state;
		}
	}
}
