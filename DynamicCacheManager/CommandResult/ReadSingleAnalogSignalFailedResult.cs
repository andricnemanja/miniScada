using System.Runtime.Serialization;

namespace DynamicCacheManager.CommandResult
{
	[DataContract]
	public class ReadSingleAnalogSignalFailedResult : CommandResultBase
	{
		[DataMember]
		public int SignalId { get; set; }
		[DataMember]
		public int RtuId { get; set; }

		public ReadSingleAnalogSignalFailedResult(int rtuId, int signalId)
		{
			SignalId = signalId;
			RtuId = rtuId;
		}
	}
}
