using System.Runtime.Serialization;

namespace DynamicCacheManager.CommandResult
{
	[DataContract]
	public class WriteDiscreteSignalCommandResult : CommandResultBase
	{
		[DataMember]
		public int RtuId { get; set; }
		public WriteDiscreteSignalCommandResult(int rtuId)
		{
			RtuId = rtuId;
		}

	}
}
