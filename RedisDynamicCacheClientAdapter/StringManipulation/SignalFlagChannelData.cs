using Contracts.DTO;

namespace RedisDynamicCacheClientAdapter.StringManipulation
{
	public class SignalFlagChannelData
	{
		public SignalFlagChannelData(int rtuId, int signalId)
		{
			RtuId = rtuId;
			SignalId = signalId;
			Operation = RtuFlagOperation.Add;
		}

		public int RtuId { get; set; }
		public int SignalId { get; set; }
		public RtuFlagOperation Operation { get; set; }
	}
}