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

		public ReadSingleDiscreteSignalResult(int rtuId, int signalId, string state) : base(rtuId)
		{
			SignalId = signalId;
			State = state;
		}
	}
}
