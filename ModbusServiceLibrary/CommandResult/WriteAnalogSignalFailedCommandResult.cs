using System.Runtime.Serialization;

namespace ModbusServiceLibrary.CommandResult
{
	[DataContract]
	public class WriteAnalogSignalFailedCommandResult : CommandResultBase
	{
		[DataMember]
		public int RtuId { get; set; }
		public string FailureReason { get; set; }
		public WriteAnalogSignalFailedCommandResult(int rtuId, string failureReason)
		{
			RtuId = rtuId;
			FailureReason = failureReason;
		}

	}
}
