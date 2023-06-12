using System.Runtime.Serialization;

namespace DynamicCacheManager.CommandResult
{
	[DataContract]
	public class ReadSingleAnalogSignalResult : CommandResultBase
	{
		[DataMember]
		public int SignalId { get; set; }
		[DataMember]
		public double SignalValue { get; set; }
		[DataMember]
		public int RtuId { get; set; }

		public ReadSingleAnalogSignalResult(int rtuId, int signalId, double signalValue)
		{
			SignalId = signalId;
			SignalValue = signalValue;
			RtuId = rtuId;
		}
	}
}
