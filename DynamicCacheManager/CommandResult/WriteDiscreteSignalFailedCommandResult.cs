using System.Runtime.Serialization;

namespace DynamicCacheManager.CommandResult
{
	[DataContract]
	public class WriteDiscreteSignalFailedCommandResult : CommandResultBase
	{
		[DataMember]
		public int RtuId { get; set; }
		public string FailureReason { get; set; }
		public WriteDiscreteSignalFailedCommandResult(int rtuId, string failureReason)
		{
			RtuId = rtuId;
			FailureReason = failureReason;
		}

	}
}
