using System.Runtime.Serialization;

namespace ModbusServiceLibrary.CommandResult
{
	[DataContract]
	public class ReadSingleDiscreteSignalResult : CommandResultBase
	{
		[DataMember]
		public int SignalId { get; set; }
		[DataMember]
		public string State { get; set; }
		[DataMember]
		public int RtuId { get; set; }

		public ReadSingleDiscreteSignalResult(int rtuId, int signalId, string state)
		{
			SignalId = signalId;
			State = state;
			RtuId = rtuId;
		}
	}
}
