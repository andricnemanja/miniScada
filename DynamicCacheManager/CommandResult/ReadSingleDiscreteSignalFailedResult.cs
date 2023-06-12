using System.Runtime.Serialization;

namespace DynamicCacheManager.CommandResult
{
	[DataContract]
	public class ReadSingleDiscreteSignalFailedResult : CommandResultBase
	{
		[DataMember]
		public int SignalId { get; set; }
		[DataMember]
		public int RtuId { get; set; }

		public ReadSingleDiscreteSignalFailedResult(int rtuId, int signalId)
		{
			SignalId = signalId;
			RtuId = rtuId;
		}
	}
}
