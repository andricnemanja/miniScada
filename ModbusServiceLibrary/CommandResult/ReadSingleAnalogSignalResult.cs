using System.Runtime.Serialization;

namespace ModbusServiceLibrary.CommandResult
{
	[DataContract]
	public class ReadSingleAnalogSignalResult : CommandResultBase
	{
		[DataMember]
		public CommandStatus CommandStatus { get; set; }
		[DataMember]
		public int SignalId { get; set; }
		[DataMember]
		public double SignalValue { get; set; }

		public ReadSingleAnalogSignalResult(int rtuId, CommandStatus commandStatus, int signalId, double signalValue) : base(rtuId)
		{
			CommandStatus = commandStatus;
			SignalId = signalId;
			SignalValue = signalValue;
		}
	}
}
