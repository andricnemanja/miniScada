using System.Runtime.Serialization;

namespace DynamicCacheManager.CommandResult
{
	[DataContract]
	public class WriteAnalogSignalCommandResult : CommandResultBase
	{
		[DataMember]
		public int RtuId { get; set; }
		public WriteAnalogSignalCommandResult(int rtuId)
		{
			RtuId = rtuId;
		}

	}
}
